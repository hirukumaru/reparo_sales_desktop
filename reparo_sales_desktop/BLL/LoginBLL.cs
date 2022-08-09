using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        public bool[] validateUserDetails(string username, string password)
        {
            try
            {
                bool[] validdata = { false, false };

                if (username.Length > 0)
                {
                    validdata[0] = true;
                }

                if (password.Length > 0)
                {
                    validdata[1] = true;
                }

                return validdata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User login(string username, string password)
        {
            try
            {
                User user = new User();

                user.username = "Dev User";

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
