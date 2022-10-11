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
    public partial class Login : Form
    {
        CompanyData compdata;

        public Login()
        {
            InitializeComponent();
        }

        public void log()
        {
            try
            {
                LoginBLL loginbll = new LoginBLL();

                User user = new User();

                bool[] ret = loginbll.validateUserDetails(tusername.Text, tpassword.Text);

                if (ret[0] == false)
                {
                    MessageBox.Show(this, "Username not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ret[1] == false)
                {
                    MessageBox.Show(this, "Password not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    user = loginbll.login(tusername.Text, tpassword.Text);

                    if (user != null)
                    {
                        Home home = new Home(user,compdata);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(this, "Invalid user name or password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log();
        }

        private void tpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }

        private void tusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                CompanyDataBLL compdatabll = new BLL.CompanyDataBLL();

                compdata = compdatabll.getCompanyData();

                if (compdata != null)
                {
                    lacompanydata.Text = compdata.CompanyName;
                }
                else
                {
                    MessageBox.Show(this, "Invalid company data.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                //pcompanylogo.BackgroundImage = Image.FromFile("C:\\REPARO\\companylogo.png");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
