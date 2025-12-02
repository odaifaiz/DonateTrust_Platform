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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        repM l = new repM();
        repD dal = new repD();

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form0 f0 = new Form0();
            f0.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l.RepId = textBox1.Text;
            l.firstname = textBox2.Text;
            l.lastname = textBox3.Text;
            l.email = textBox4.Text;
            l.phone = textBox5.Text;
            l.password = textBox6.Text;
            l.income = textBox8.Text;
            l.location = textBox9.Text;
            l.familymember = textBox7.Text;
            
            // l.usertype = radioButton1.Text;

            //Check the Login Credentials
            bool isSuccess = dal.loginCheck(l);

            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
