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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        volunteer_tblM l = new volunteer_tblM();
        volunteer_tblD dal = new volunteer_tblD();



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Let's Add the Dunctionality to Search the Donor

            //1. Get the Keywords Typed on the Search TExt Box
            string keywords = textBox1.Text;

            // Check Whether the Search TExtBox is Empty or Not
            if (keywords != null)
            {
                //Display the information of Donors Based on Keywords
                DataTable dt = dal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                //DIsplay all the Donors
                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form0 f0 = new Form0();
            f0.ShowDialog();
        }

        private void Form23_Load(object sender, EventArgs e)
        {

        }
    }
}
