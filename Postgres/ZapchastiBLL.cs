using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres
{
    class ZapchastiBLL
    {
        ZapchastiDAL dalZapchasti;
        public ZapchastiBLL()
        {
            dalZapchasti = new ZapchastiDAL();
        }
        public DataTable getAllZapchasti()
        {
            return dalZapchasti.getAllZapchasti();
        }
        public bool InsertZapchasti(tblZapchasti sang)
        {
            return dalZapchasti.InsertZapchasti(sang);
        }
        public bool UpdateZapchasti(tblZapchasti sang)
        {
            return dalZapchasti.UpdateZapchasti(sang);
        }
        public bool DeleteZapchasti(tblZapchasti sang)
        {
            return dalZapchasti.DeleteZapchasti(sang);
        }
        public DataTable FindZapchasti7(string sang)
        {
            return dalZapchasti.FindZapchasti7(sang);
        }
        public DataTable FindZapchasti8(string sang)
        {
            return dalZapchasti.FindZapchasti8(sang);
        }
        public DataTable FindZapchasti9(string sang)
        {
            return dalZapchasti.FindZapchasti9(sang);
        }
    }
}
