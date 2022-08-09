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
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginBLL loginbll = new LoginBLL();

            User user = new User();

            bool[] ret = loginbll.validateUserDetails(tusername.Text, tpassword.Text);

            if (ret[0] == false)
            {
                MessageBox.Show(this,"Username not valid","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

                }
                else
                {

                }
            }            
        }
    }
}
