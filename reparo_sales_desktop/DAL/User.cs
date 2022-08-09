using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class User
    {
        int user_id { get; set; }
        string full_name { get; set; }
        string username { get; set; }
        string password { get; set; }
        string user_typ { get; set; }
        bool is_active { get; set; }

    }
}
