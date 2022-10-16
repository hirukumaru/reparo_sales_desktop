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
    public partial class Home : Form
    {
        private int childFormNumber = 0;

        public User loggedUser;
        public CompanyData companyData;

        public Home(User user, CompanyData company)
        {
            loggedUser = user;
            companyData = company;

            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }        

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Text = companyData.CompanyName + " - Home";
            totipcurrentuser.Text = "| Current User : " + loggedUser.full_name + " | Access Level : " + loggedUser.user_type + " | ";

            MenuAccessBLL access = new MenuAccessBLL();

            MenuAccess ma = access.getMenuAccessList(loggedUser.company_id, loggedUser.user_id);

            itemsMenu.Visible = ma.items;
            itemsBar.Visible = ma.items;
            salesMenu.Visible = ma.sales;
            salesBar.Visible = ma.sales;
            stockMenu.Visible = ma.stock;
            stockBar.Visible = ma.stock;
            paymentsMenu.Visible = ma.payment;
            paymentBar.Visible = ma.payment;
            reportsMenu.Visible = ma.reports;
            reportsBar.Visible = ma.reports;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemList il = new ItemList();
            il.MdiParent = this;
            il.Show();
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewItem ni = new NewItem(loggedUser);
            ni.MdiParent = this;
            ni.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSale ns = new NewSale(loggedUser);
            ns.MdiParent = this;
            ns.Show();
        }

        private void newSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewSale ns = new NewSale(loggedUser);
            ns.MdiParent = this;
            ns.Show();
        }
    }
}
