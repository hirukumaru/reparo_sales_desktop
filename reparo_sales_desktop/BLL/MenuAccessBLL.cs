using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class MenuAccessBLL
    {
        public MenuAccess getMenuAccessList(int companyId)
        {
            MenuAccess ma = new MenuAccess();

            DB db = new DB();

            DataSet dset = db.getData("exec getMenuAccessList " + 1);

            ma.items = Convert.ToBoolean(dset.Tables[0].Rows[0].ItemArray[0]);
            ma.sales = Convert.ToBoolean(dset.Tables[0].Rows[0].ItemArray[1]);
            ma.stock = Convert.ToBoolean(dset.Tables[0].Rows[0].ItemArray[2]);
            ma.payment = Convert.ToBoolean(dset.Tables[0].Rows[0].ItemArray[3]);
            ma.reports = Convert.ToBoolean(dset.Tables[0].Rows[0].ItemArray[4]);            

            return ma;
        }

    }
}
