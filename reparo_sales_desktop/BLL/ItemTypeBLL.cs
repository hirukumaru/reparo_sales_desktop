using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ItemTypeBLL
    {
        public List<ItemType> getItemTypes()
        {
            try
            {
                List<ItemType> itemtypes = new List<ItemType>();

                DataSet types = DB.getData("exec getItemTypes");

                foreach (DataRow type in types.Tables[0].Rows)
                {
                    itemtypes.Add
                    (
                        new ItemType
                        {
                            ItemTypeId = Convert.ToInt32(type.ItemArray[0]),
                            ItemTypeDesc = Convert.ToString(type.ItemArray[1])
                        }
                    );
                }

                return itemtypes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
