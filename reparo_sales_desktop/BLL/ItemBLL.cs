using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ItemBLL
    {
        public List<Item> getAllItems()
        {
            try
            {
                DataSet items = DB.getData("exec getAllItems");

                List<Item> itemlistret = new List<Item>();

                foreach (DataRow item in items.Tables[0].Rows)
                {
                    itemlistret.Add
                    (
                        new Item
                        {
                            ItemId = Convert.ToInt32(item.ItemArray[0]),
                            ItemCode = Convert.ToString(item.ItemArray[1]),
                            ItemTypeId = Convert.ToInt32(item.ItemArray[2]),
                            ItemType = Convert.ToString(item.ItemArray[3]),
                            ItemName = Convert.ToString(item.ItemArray[4]),
                            Cost = Convert.ToDecimal(item.ItemArray[5]),
                            SalesPrice = Convert.ToDecimal(item.ItemArray[6]),
                            DiscountPrcentsge = Convert.ToDecimal(item.ItemArray[7]),
                            IsActive = Convert.ToBoolean(item.ItemArray[8]),
                            LastModified = Convert.ToString(item.ItemArray[9]),
                            ModifiedUserId = Convert.ToInt32(item.ItemArray[10]),
                            ModifiedBy = Convert.ToString(item.ItemArray[11])

                        }
                    );

                    //itemlistret = itemlist;
                }

                return itemlistret;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public string getItemCode(int itemTypeId)
        {
            try
            {
                string itemcode = Convert.ToString(DB.getData("exec getItemCode " + itemTypeId).Tables[0].Rows[0].ItemArray[0]);

                return itemcode;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public bool createItem(Item item)
        {
            try
            {
                return DB.runQuery("exec createItem " + item.ItemTypeId + "," + item.ItemCode + ",'" +
                item.ItemName + "'," + item.Cost + "," + item.SalesPrice + "," + item.DiscountPrcentsge + "," +
                item.IsActive + "," + item.ModifiedUserId);
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public List<Item> getActiveItems()
        {
            try
            {
                DataSet items = DB.getData("exec getAllItems");

                List<Item> itemlistret = new List<Item>();

                foreach (DataRow item in items.Tables[0].Rows)
                {
                    if (Convert.ToBoolean(item.ItemArray[8]) == true)
                    {
                        itemlistret.Add
                        (
                            new Item
                            {
                                ItemId = Convert.ToInt32(item.ItemArray[0]),
                                ItemCode = Convert.ToString(item.ItemArray[1]),
                                ItemTypeId = Convert.ToInt32(item.ItemArray[2]),
                                ItemType = Convert.ToString(item.ItemArray[3]),
                                ItemName = Convert.ToString(item.ItemArray[4]),
                                Cost = Convert.ToDecimal(item.ItemArray[5]),
                                SalesPrice = Convert.ToDecimal(item.ItemArray[6]),
                                DiscountPrcentsge = Convert.ToDecimal(item.ItemArray[7]),
                                IsActive = Convert.ToBoolean(item.ItemArray[8]),
                                LastModified = Convert.ToString(item.ItemArray[9]),
                                ModifiedUserId = Convert.ToInt32(item.ItemArray[10]),
                                ModifiedBy = Convert.ToString(item.ItemArray[11])

                            }
                        );
                    }                    

                    //itemlistret = itemlist;
                }

                return itemlistret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
