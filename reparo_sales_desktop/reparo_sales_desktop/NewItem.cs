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
    public partial class NewItem : Form
    {
        User loggedUser;

        public NewItem(User user)
        {
            InitializeComponent();

            loggedUser = user;
        }

        public void clearNewItemWindow()
        {
            titemcode.Clear();
            titemname.Clear();
            tcost.Clear();
            tsalesprice.Clear();
            tdiscountprecentage.Clear();
            cbisactive.CheckState = CheckState.Unchecked;
            cbitemtype.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NewItem_Load(object sender, EventArgs e)
        {
            try
            {
                ItemTypeBLL ittybll = new ItemTypeBLL();

                cbitemtype.DataSource = ittybll.getItemTypes();
                cbitemtype.DisplayMember = "ItemTypeDesc";
                cbitemtype.ValueMember = "ItemTypeId";

                cbitemtype.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void cbitemtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ItemBLL itembll = new ItemBLL();

                titemcode.Text = itembll.getItemCode(Convert.ToInt32(cbitemtype.SelectedValue));
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();

                item.ItemTypeId = Convert.ToInt32(cbitemtype.SelectedValue);
                item.ItemCode = titemcode.Text;
                item.ItemName = titemname.Text;
                item.Cost = Convert.ToDecimal(tcost.Text);
                item.SalesPrice = Convert.ToDecimal(tsalesprice.Text);
                item.DiscountPrcentsge = Convert.ToDecimal(tdiscountprecentage.Text);
                item.IsActive = Convert.ToBoolean(cbisactive.CheckState);
                item.ModifiedUserId = loggedUser.user_id;

                ItemBLL itembll = new ItemBLL();

                bool ret = itembll.createItem(item);

                if (ret)
                {
                    MessageBox.Show(this, "New item saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearNewItemWindow();
                }
                else
                {
                    MessageBox.Show(this, "Item unabled to saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
