using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;

namespace reparo_sales_desktop
{
    public partial class ItemList : Form
    {
        public ItemList()
        {
            InitializeComponent();
        }

        public void fillItemGrid(List<Item> items)
        {
            try
            {
                for (int i = 0; i < items.Count(); i++)
                {
                    griditemlist.Rows.Add();

                    if (items[i].IsActive == false)
                    {
                        griditemlist.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else
                    {
                        griditemlist.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }

                    griditemlist.Rows[i].Cells[0].Value = items[i].ItemId;
                    griditemlist.Rows[i].Cells[1].Value = items[i].ItemCode;
                    griditemlist.Rows[i].Cells[2].Value = items[i].ItemType;
                    griditemlist.Rows[i].Cells[3].Value = items[i].ItemName;
                    griditemlist.Rows[i].Cells[4].Value = items[i].Cost.ToString("N2");
                    griditemlist.Rows[i].Cells[5].Value = items[i].SalesPrice.ToString("N2");
                    griditemlist.Rows[i].Cells[6].Value = items[i].DiscountPrcentsge.ToString("N2");
                    griditemlist.Rows[i].Cells[7].Value = items[i].IsActive;
                    griditemlist.Rows[i].Cells[8].Value = items[i].LastModified;
                    griditemlist.Rows[i].Cells[9].Value = items[i].ModifiedBy;
                }

                larowcount.Text = items.Count() + " Items In List";
            }
            catch (Exception ex)
            {

            }
        }

        private void ItemList_Load(object sender, EventArgs e)
        {
            try
            {
                griditemlist.Rows.Clear();

                ItemBLL itembll = new ItemBLL();

                fillItemGrid(itembll.getAllItems());

                griditemlist.ClearSelection();

                griditemlist.CurrentCell = null;
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                griditemlist.Rows.Clear();

                ItemBLL itembll = new ItemBLL();

                fillItemGrid(itembll.getAllItems());

                griditemlist.ClearSelection();

                griditemlist.CurrentCell = null;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
