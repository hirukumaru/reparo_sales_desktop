using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Customer
    {
        public int CusId {get; set;}
        public string CusName { get; set; }
        public string CusAddress { get; set; }
        public string CusContactNo { get; set; }
        public bool IsActive { get; set; }
    }
}
