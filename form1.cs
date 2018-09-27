using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   
        Login log = new Login();
        main page = new main();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your username and password", "ERROR | Hotel Automation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                log.login(txtUser.Text, txtPassword.Text, DateTime.Now);

                string holdInfo = txtUser.Text + "" + txtPassword.Text.ToString();
                if (log.loginInfo == holdInfo)
                {
                    page.Show();
                    this.Hide();



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }
    }
}

