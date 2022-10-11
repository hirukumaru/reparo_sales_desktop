using System;
using System.Collections.Generic;
using System.Data;
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

                DataSet userData = DB.getData("exec login " + username +","+ password);

                if (userData != null)
                {
                    user.user_id = Convert.ToInt32(userData.Tables[0].Rows[0].ItemArray[0]);
                    user.company_id = Convert.ToInt32(userData.Tables[0].Rows[0].ItemArray[1]);
                    user.full_name = Convert.ToString(userData.Tables[0].Rows[0].ItemArray[2]);
                    user.username = Convert.ToString(userData.Tables[0].Rows[0].ItemArray[3]);
                    user.user_type_id = Convert.ToInt32(userData.Tables[0].Rows[0].ItemArray[5]);
                    user.user_type = Convert.ToString(userData.Tables[0].Rows[0].ItemArray[6]);
                }                

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
