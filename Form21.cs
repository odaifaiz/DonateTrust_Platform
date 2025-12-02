using SPF.Model;
using SPF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPF
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        volunteer_tblM l = new volunteer_tblM();
        volunteer_tblD dal = new volunteer_tblD();

        private void button1_Click(object sender, EventArgs e)
        {

            // l.usertype = radioButton1.Text;

            //Check the Login Credentials
            l.VolId = textBox1.Text;

            bool isSuccess = dal.loginCheck(l);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Login Failed.");
                
            }
            else
            {
                this.Hide();
                Form14 f14 = new Form14();
                f14.ShowDialog();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }
    }
}
