using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres
{
    class ZapchastiDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public ZapchastiDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllZapchasti()
        {
            string sql = "select * from tblZapchasti";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertZapchasti(tblZapchasti sang)
        {
            string sql = "INSERT INTO tblZapchasti(Code, PartName, Price, NumberOfSold, NumberOfRemaining, TotalAmount) VALUES(@Code, @PartName, @Price, @NumberOfSold, @NumberOfRemaining, @TotalAmount)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Code", SqlDbType.Int).Value = sang.Code;
                cmd.Parameters.Add("@PartName", SqlDbType.NVarChar).Value = sang.PartName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = sang.Price;
                cmd.Parameters.Add("@NumberOfSold", SqlDbType.Int).Value = sang.NumberOfSold;
                cmd.Parameters.Add("@NumberOfRemaining", SqlDbType.Int).Value = sang.NumberOfRemaining;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Int).Value = sang.TotalAmount;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateZapchasti(tblZapchasti sang)
        {
            string sql = "update tblZapchasti set Code =@Code, PartName =@PartName, Price =@Price, NumberOfSold =@NumberOfSold, NumberOfRemaining =@NumberOfRemaining, TotalAmount =@TotalAmount where id = @id";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Code", SqlDbType.Int).Value = sang.Code;
                cmd.Parameters.Add("@PartName", SqlDbType.NVarChar).Value = sang.PartName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = sang.Price;
                cmd.Parameters.Add("@NumberOfSold", SqlDbType.Int).Value = sang.NumberOfSold;
                cmd.Parameters.Add("@NumberOfRemaining", SqlDbType.Int).Value = sang.NumberOfRemaining;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Int).Value = sang.TotalAmount;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteZapchasti(tblZapchasti sang)
        {
            string sql = "delete tblZapchasti where id = @id";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sang.id;               
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindZapchasti7(string sang)
        {
            string sql = "SELECT * from tblZapchasti WHERE Code like'%" + sang + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FindZapchasti8(string sang)
        {
            string sql = "SELECT * from tblZapchasti WHERE PartName like'%" + sang + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FindZapchasti9(string sang)
        {
            string sql = "SELECT * from tblZapchasti WHERE Price like'%" + sang + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
