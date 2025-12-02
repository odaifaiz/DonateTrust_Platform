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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SPF
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        tblM l = new tblM();
        tblD dal = new tblD();
        private void button1_Click(object sender, EventArgs e)
        {
            
            l.cnic = textBox1.Text;
            // l.usertype = radioButton1.Text;

            //Check the Login Credentials
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }
    }
}
