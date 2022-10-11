using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class CompanyDataBLL
    {
        public CompanyData getCompanyData()
        {
            try
            {
                CompanyData compdata = new CompanyData();

                DataSet cd = DB.getData("exec getCompanyData");

                compdata.CompanyId = Convert.ToInt32(cd.Tables[0].Rows[0].ItemArray[0]);
                compdata.CompanyName = Convert.ToString(cd.Tables[0].Rows[0].ItemArray[1]);
                compdata.CompanyAdress = Convert.ToString(cd.Tables[0].Rows[0].ItemArray[2]);
                compdata.CompanyEmail = Convert.ToString(cd.Tables[0].Rows[0].ItemArray[3]);
                compdata.CompanyPhoneNo = Convert.ToString(cd.Tables[0].Rows[0].ItemArray[4]);

                return compdata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
