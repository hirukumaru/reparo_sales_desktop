using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class User
    {
        public int user_id { get; set; }
        public int company_id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int user_type_id { get; set; }
        public string user_type { get; set; }
        public bool is_active { get; set; }

    }
}
