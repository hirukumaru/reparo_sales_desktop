using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class CustomerBLL
    {
        public List<Customer> getActiveCustomers()
        {
            try
            {
                DataSet customers = DB.getData("exec getActiveCustomers");

                List<Customer> customerlist = new List<Customer>();

                foreach (DataRow customer in customers.Tables[0].Rows)
                {
                    customerlist.Add
                    (
                        new Customer
                        {
                            CusId = Convert.ToInt32(customer.ItemArray[0]),
                            CusName = Convert.ToString(customer.ItemArray[1]),
                            CusAddress = Convert.ToString(customer.ItemArray[2]),
                            CusContactNo = Convert.ToString(customer.ItemArray[3])
                        }
                    );
                }

                return customerlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }    
}
