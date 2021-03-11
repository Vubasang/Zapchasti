using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postgres
{
    public partial class Form1 : Form
    {
        string conStr = "Data Source = DESKTOP-TAL0KGO\\SQLEXPRESS; Initial Catalog = Zapchasti; Integrated Security=true";
        string flag;
        DataTable dtZapchasti;
        int index;
        ZapchastiBLL bllZapchasti;
        public Form1()
        {
            InitializeComponent();
            bllZapchasti = new ZapchastiBLL();
        }
        public DataTable createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("PartName");
            dt.Columns.Add("Price");
            dt.Columns.Add("NumberOfSold");
            dt.Columns.Add("NumberOfRemaining");
            dt.Columns.Add("TotalAmount");
            return dt;
        }
        public void ShowAllZapchasti()
        {
            DataTable dt = bllZapchasti.getAllZapchasti();
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            LockControl();
            dtZapchasti = createTable();
            ShowAllZapchasti();
        }
        public bool CheckData()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Вы не ввели Код запчасти", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Вы не ввели Название задчасти", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Вы не ввели Цену", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNumberOfSold.Text))
            {
                MessageBox.Show("Вы не ввели Количество проданных", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberOfSold.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNumberOfRemaining.Text))
            {
                MessageBox.Show("Вы не ввели Количество оставшихся", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberOfRemaining.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                MessageBox.Show("Вы не ввели Общее количество", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotalAmount.Focus();
                return false;
            }
            return true;
        }
        public void LockControl()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;

            txtCode.ReadOnly = true;
            txtPartName.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtNumberOfSold.ReadOnly = true;
            txtNumberOfRemaining.ReadOnly = true;
            txtTotalAmount.ReadOnly = true;

            button1.Focus();
        }
        public void UnlockCotrol()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;

            txtCode.ReadOnly = false;
            txtPartName.ReadOnly = false;
            txtPrice.ReadOnly = false;
            txtNumberOfSold.ReadOnly = false;
            txtNumberOfRemaining.ReadOnly = false;
            txtTotalAmount.ReadOnly = false;
            txtCode.Focus();
        }
        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            string value = txtFindCode.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllZapchasti.FindZapchasti7(value);
                dataGridView1.DataSource = dt;
            }
            else
                ShowAllZapchasti();
        }

        private void txtFindPartName_TextChanged(object sender, EventArgs e)
        {
            string value = txtFindPartName.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllZapchasti.FindZapchasti8(value);
                dataGridView1.DataSource = dt;
            }
            else
                ShowAllZapchasti();
        }

        private void txtFindPrice_TextChanged(object sender, EventArgs e)
        {
            string value = txtFindPrice.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllZapchasti.FindZapchasti9(value);
                dataGridView1.DataSource = dt;
            }
            else
                ShowAllZapchasti();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Quesion;
            Quesion = MessageBox.Show("Вы хотите выйти?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Quesion == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UnlockCotrol();
            flag = "add";

            txtCode.Text = "";
            txtPartName.Text = "";
            txtPrice.Text = "";
            txtNumberOfSold.Text = "";
            txtNumberOfRemaining.Text = "";
            txtTotalAmount.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnlockCotrol();
            flag = "edit";
        }

        int ID;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            if (Index >= 0)
            {
                ID = Int32.Parse(dataGridView1.Rows[Index].Cells["Column7"].Value.ToString());
                txtCode.Text = dataGridView1.Rows[Index].Cells["Code"].Value.ToString();
                txtPartName.Text = dataGridView1.Rows[Index].Cells["PartName"].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[Index].Cells["Price"].Value.ToString();
                txtNumberOfSold.Text = dataGridView1.Rows[Index].Cells["NumberOfSold"].Value.ToString();
                txtNumberOfRemaining.Text = dataGridView1.Rows[Index].Cells["NumberOfRemaining"].Value.ToString();
                txtTotalAmount.Text = dataGridView1.Rows[Index].Cells["TotalAmount"].Value.ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                if (CheckData())
                {
                    tblZapchasti sang = new tblZapchasti();
                    sang.Code = int.Parse(txtCode.Text);
                    sang.PartName = txtPartName.Text;
                    sang.Price = int.Parse(txtPrice.Text);
                    sang.NumberOfSold = int.Parse(txtNumberOfSold.Text);
                    sang.NumberOfRemaining = int.Parse(txtNumberOfRemaining.Text);
                    sang.TotalAmount = int.Parse(txtTotalAmount.Text);
                    if (bllZapchasti.InsertZapchasti(sang))
                        ShowAllZapchasti();
                    else
                        MessageBox.Show("Произошла ошибка", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (flag == "edit")
            {
                if (CheckData())
                {
                    tblZapchasti sang = new tblZapchasti();
                    sang.id = ID;
                    sang.Code = int.Parse(txtCode.Text);
                    sang.PartName = txtPartName.Text;
                    sang.Price = int.Parse(txtPrice.Text);
                    sang.NumberOfSold = int.Parse(txtNumberOfSold.Text);
                    sang.NumberOfRemaining = int.Parse(txtNumberOfRemaining.Text);
                    sang.TotalAmount = int.Parse(txtTotalAmount.Text);
                    if (bllZapchasti.UpdateZapchasti(sang))
                        ShowAllZapchasti();
                    else
                        MessageBox.Show("Произошла ошибка", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            LockControl();
        }

        public void load()
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                string sql = "select *from tblZapchasti";
                SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла ошибка:" + e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult notification;
            notification = MessageBox.Show("Вы хотите удалить эти информации?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (notification == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                string sql = "delete from tblZapchasti where Code like '%" + txtCode.Text + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Успешно удалить!");
                load();
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "ID";
            ExcelApp.Cells[1, 2] = "Код запчасти";
            ExcelApp.Cells[1, 3] = "Название запчасти";
            ExcelApp.Cells[1, 4] = "Цена";
            ExcelApp.Cells[1, 5] = "Количество проданных";
            ExcelApp.Cells[1, 6] = "Количество оставшихся";
            ExcelApp.Cells[1, 7] = "Общее количество";

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    ExcelApp.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
