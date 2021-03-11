using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres
{
    class tblZapchasti
    {
        public int id { set; get; }
        public int Code { set; get; }
        public string PartName { set; get; }
        public int Price { set; get; }
        public int NumberOfSold { set; get; }
        public int NumberOfRemaining { set; get; }
        public int TotalAmount { set; get; }
    }
}
