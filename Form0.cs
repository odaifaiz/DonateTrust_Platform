using SPF.Model;
using SPF.Data;
using System;
using System.CodeDom;
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
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        loginM l = new loginM();
        loginD dal = new loginD();

        

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور.");
                return;
            }

          
            string userType = null;

            if (radioButton1.Checked)
                userType = "Admin";      
            else if (radioButton2.Checked)
                userType = "Donor";       
            else if (radioButton3.Checked)
                userType = "Volunteer";   // متطوع

            if (userType == null)
            {
                MessageBox.Show("يرجى اختيار نوع المستخدم (مدير / متبرع / متطوع).");
                return;
            }

            // 3) تعبئة الكائن l وإرساله للـ DAL
            l.username = username;
            l.password = password;
            l.usertype = userType;

            bool isSuccess = dal.loginCheck(l);

            if (!isSuccess)
            {
                // فشل تسجيل الدخول
                MessageBox.Show("بيانات الدخول غير صحيحة، تأكد من المعلومات وحاول مرة أخرى.");
                return;
            }

            // 4) تسجيل الدخول ناجح – افتح الفورم المناسب حسب النوع
            MessageBox.Show("تم تسجيل الدخول بنجاح.");

            this.Hide();

            if (userType == "Admin")
            {
                // فورم المدير
                Form13 f13 = new Form13();
                f13.ShowDialog();
            }
            else if (userType == "Donor")
            {
                // فورم المتبرع
                Form18 f18 = new Form18();
                f18.ShowDialog();
            }
            else if (userType == "Volunteer")
            {
                // فورم المتطوع
                Form23 f23 = new Form23();
                f23.ShowDialog();
            }

            this.Show();
        }



        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
