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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        volunteer_dataM d = new volunteer_dataM();
        volunteer_dataD dal = new volunteer_dataD();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //We will write the code to Add new Donor
            //Step 1. Get the DAta from Manage Donors Form
            d.VolId = textBox1.Text;
            d.programs = comboBox1.Text;
            d.task = textBox2.Text;

            //Step2: Inserting Data into Database
            //Create a Boolean Variable to Isnert DAta into DAtabase and check whether the data inserted successfully of not
            bool isSuccess = dal.Insert(d);

            //if the Data is inserted successfully then the values of isSuccess will be True else it will be false
            if (isSuccess == true)
            {
                //Data Inserted Successfully
                MessageBox.Show("Your task has been assigned :)");

            }
            else
            {
                //FAiled to Insert Data
                MessageBox.Show("Failed to assign task :(");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }
    }
}
