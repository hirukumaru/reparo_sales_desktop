using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    internal class DB
    {
        SqlConnection conn = new SqlConnection("");

        public DataSet getData(string query)
        {
            try
            {
                DataSet dset = null;

                SqlDataAdapter dadp = new SqlDataAdapter(query,conn);

                dadp.Fill(dset);

                return dset;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool runQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query,conn);

                bool ret = Convert.ToBoolean(cmd.ExecuteNonQuery());

                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
