using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace reparo_sales_desktop.DAL
{
    internal class Db
    {
        SqlConnection conn = new SqlConnection("");

        public DataSet getData(String query)
        {
            try
            {
                DataSet dset = null;

                SqlDataAdapter dadp = new SqlDataAdapter(query, conn);
                dadp.Fill(dset);

                return dset;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool runQuery(String query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
