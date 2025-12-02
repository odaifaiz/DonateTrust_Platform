using SPF.Data;
using SPF.Model;
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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        donor_dataD dal = new donor_dataD();
        donor_dataM d = new donor_dataM();
        List<donor_dataM> list;


        private void lblDonorID_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Let's Add the Dunctionality to Search the Donors

            //1. Get the Keywords Typed on the Search TExt Box
            string keywords = txtSearch.Text;

            // Check Whether the Search TExtBox is Empty or Not
            if (keywords != null)
            {
                //Display the information of Donors Based on Keywords
                DataTable dt = dal.Search(keywords);
                dgvDonors.DataSource = dt;
            }
            else
            {
                //DIsplay all the Donors
                DataTable dt = dal.Select();
                dgvDonors.DataSource = dt;
            }
        }
        public void Clear()
        {
            //Clear all the TExtboxes
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

            private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Add the Functionality to Update the Donors
            //1. Get the Values from Form
            
            d.firstName = txtFirstName.Text;
            d.lastName = txtLastName.Text;
            d.DonorId = textBox1.Text;
            d.phone = textBox2.Text;
            d.email = txtEmail.Text;
            d.password = textBox3.Text;
         

            //Create a Boolean Variable to Check whether the data updated successfully or not
            bool isSuccess = dal.Update(d);



            //If the data updated successfully then the value of isSuccess will be true else it will be false
            if (isSuccess == true)
            {
                //Donor Updated Successfully
                MessageBox.Show("Donor updated Successfully.");
                //Clear();

                //Refresh Datagridview
                DataTable dt = dal.Select();
                dgvDonors.DataSource = dt;

            }
            else
            {
                //Failed to Update
                MessageBox.Show("Failed to update donors.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the value from form
            // d.cnic = int.Parse(textBox1.TextChanged);

            //Check whether the donor has profile picture or not
            d.DonorId = textBox1.Text;


            //Create a Boolean Variable to Check whether the donor deleted or not
            bool isSuccess = dal.Delete(d);

            if (isSuccess == true)
            {
                //Donor DeletA
                //Refresh Datagrid View
                DataTable dt = dal.Select();
                dgvDonors.DataSource = dt;
            }
            else
            {
                //Failed to Delete Donor
                MessageBox.Show("Failed to Delete Donor");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the TExtboxes
            Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }
    }
}
