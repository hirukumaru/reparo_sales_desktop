using reparo_sales_desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reparo_sales_desktop.BLL
{
    internal class Login
    {
        public User login(String username, String password)
        {
            try
            {
                User user = new User();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }    
}
