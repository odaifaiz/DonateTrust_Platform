using SPF.Model;
using SPF.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SPF
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        // تحميل كل التبرعات
        private void LoadTransactions()
        {
            using (var ctx = new SpfContext())
            {
                var list = ctx.Transactions
                              .Select(t => new
                              {
                                  t.TransId,
                                  t.DonorId,
                                  DonorName = t.Donor.firstName + " " + t.Donor.lastName,
                                  t.programs,
                                  t.amount
                              })
                              .ToList();

                dgvDonors.DataSource = list;
            }
        }

        // البحث
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text.Trim();

            using (var ctx = new SpfContext())
            {
                var query = ctx.Transactions.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keywords))
                {
                    query = query.Where(t =>
                        t.TransId.Contains(keywords) ||
                        t.DonorId.Contains(keywords) ||
                        t.programs.Contains(keywords) ||
                        t.amount.Contains(keywords) ||
                        t.Donor.firstName.Contains(keywords) ||
                        t.Donor.lastName.Contains(keywords)
                    );
                }

                var list = query
                    .Select(t => new
                    {
                        t.TransId,
                        t.DonorId,
                        DonorName = t.Donor.firstName + " " + t.Donor.lastName,
                        t.programs,
                        t.amount
                    })
                    .ToList();

                dgvDonors.DataSource = list;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void dgvDonors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
