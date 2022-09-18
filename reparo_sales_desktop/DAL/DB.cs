using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DB
    {
        public SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ReparoSales;User ID=sa;Password=REPARO");

        public DataSet getData(string query)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                DataSet dset = new DataSet();

                SqlDataAdapter dadp = new SqlDataAdapter(query, conn);              

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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

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
