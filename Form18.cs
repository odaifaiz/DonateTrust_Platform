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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        transaction_dataDAL tDal = new transaction_dataDAL();


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1) قراءة البيانات من الفورم
            string donorId = textBox1.Text.Trim();   // DonorId
            string program = comboBox1.Text;        // البرنامج
            string amountTxt = textBox2.Text.Trim();  // المبلغ (كنص حالياً)

            if (string.IsNullOrWhiteSpace(donorId) ||
                string.IsNullOrWhiteSpace(program) ||
                string.IsNullOrWhiteSpace(amountTxt))
            {
                MessageBox.Show("Please fill all fields (Donor ID, Program, Amount).");
                return;
            }

            using (var ctx = new SpfContext())
            {
                // 2) تأكد أن المتبرع موجود في جدول donor_data
                var donor = ctx.Donors.SingleOrDefault(d => d.DonorId == donorId);
                if (donor == null)
                {
                    MessageBox.Show("Donor not found. Please check Donor ID.");
                    return;
                }

                // 3) إنشاء كائن التبرع وربطه بالمتبرع
                var donation = new transaction_dataM
                {
                    TransId = Guid.NewGuid().ToString(),  // ✅ توليد رقم تبرع فريد
                    DonorId = donorId,                    // المفتاح الأجنبي
                    programs = program,
                    amount = amountTxt
                };

                ctx.Transactions.Add(donation);

                // (اختياري) تحديث إجمالي التبرعات في جدول المتبرعين
                /*
                if (decimal.TryParse(donor.amount, out var currentTotal) &&
                    decimal.TryParse(amountTxt, out var newAmount))
                {
                    donor.amount = (currentTotal + newAmount).ToString();
                }
                */

                // 4) حفظ التغييرات
                int rows = ctx.SaveChanges();
                if (rows > 0)
                {
                    MessageBox.Show("Congratulations!!! Your donation has been received :)");
                }
                else
                {
                    MessageBox.Show("Failed to receive your donation :(");
                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form0 f0 = new Form0();
            f0.ShowDialog();
        }

        private void Form18_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
