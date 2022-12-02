using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;

namespace reparo_sales_desktop
{
    public partial class NewSale : Form
    {
        public List<Item> itemList;

        public NewSale(User user)
        {
            InitializeComponent();
        }

        public void getActiveCustomers()
        {
            try
            {
                CustomerBLL cbll = new CustomerBLL();

                List<Customer> customers = cbll.getActiveCustomers();

                cbcustomer.DataSource = customers;
                cbcustomer.DisplayMember = "CusName";
                cbcustomer.ValueMember = "CusId";
            }
            catch (Exception ex)
            {

            }
        }

        public void getAllItems()
        {
            try
            {
                ItemBLL ibll = new ItemBLL();

                List<Item> items = ibll.getActiveItems();

                itemList = items;

                cbitemname.DataSource = items;
                cbitemname.DisplayMember = "ItemName";
                cbitemname.ValueMember = "ItemId";
            }
            catch (Exception ex)
            {

            }
        }

        public Item findItem(int itemid)
        {
            return itemList.Find(i => i.ItemId == itemid);
        }

        public void getItemDataByCode(String itemcode)
        {
            try
            {
                Item item = itemList.Find(i => i.ItemCode == itemcode);

                if (item != null)
                {
                    cbitemname.Text = item.ItemName;
                }
                else
                {
                    getAllItems();
                    titemcode.Text = "";
                    cbitemname.Text = "";
                    tunitprice.Text = "";
                    lastock.Text = "";
                    laminprice.Text = "";
                }
                
            }
            catch (Exception ex)
            {

            }            
        }

        public void showItemData()
        {
            try
            {
                if (cbitemname.Text.Length > 0 && cbitemname.Text != "DAL.Item")
                {
                    laitemid.Text = Convert.ToString(cbitemname.SelectedValue);

                    Item selecteditem = findItem(Convert.ToInt32(laitemid.Text));

                    titemcode.Text = selecteditem.ItemCode;
                    tunitprice.Text = Convert.ToString(selecteditem.SalesPrice);
                    lastock.Text = "0";
                    laminprice.Text = Convert.ToString(selecteditem.SalesPrice - ((selecteditem.DiscountPrcentsge / 100) * selecteditem.SalesPrice));
                }
                else
                {
                    laitemid.Text = " ";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void NewSale_Load(object sender, EventArgs e)
        {
            getActiveCustomers();
            lacusid.Text = Convert.ToString(cbcustomer.SelectedValue);

            getAllItems();
            cbitemname.Text = "";         
        }

        private void cbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbcustomer_TextChanged(object sender, EventArgs e)
        {
            if (cbcustomer.Text.Length > 0)
            {
                lacusid.Text = Convert.ToString(cbcustomer.SelectedValue);
            }            
        }

        private void cbitemname_SelectedIndexChanged(object sender, EventArgs e)
        {
            showItemData();
        }

        private void cbitemname_TextChanged(object sender, EventArgs e)
        {
            showItemData();
        }

        private void laitemid_Click(object sender, EventArgs e)
        {

        }

        private void laitemid_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void titemcode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void titemcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getItemDataByCode(titemcode.Text);
            }
        }

        private void titemcode_Leave(object sender, EventArgs e)
        {
            getItemDataByCode(titemcode.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
