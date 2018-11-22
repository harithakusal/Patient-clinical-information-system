using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Patient_clinical_information_system
{
    public partial class searchForm : Form
    {
        public searchForm()
        {
            InitializeComponent();

            
        }

        private void searchForm_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void profileLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void displayUN_Click(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            start s = new start();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string retrievePI = "SELECT * FROM PersonalInfo WHERE nic = '" + searchBox.Text + "'; ";
            string retrieveCI = "SELECT * FROM clinicalInfo WHERE nic = '" + searchBox.Text + "'; ";
            string retrieveNIC = "SELECT * FROM clinicalInfo WHERE nic = '" + searchBox.Text + "'; ";

            SqlConnection con = new SqlConnection(SignInForm.myConnection);

            try
            {
                con.Open();
                
                SqlCommand command = new SqlCommand(retrieveNIC, con);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    string DBnic = reader["nic"].ToString();

                    con.Close();
                    
                    if (searchBox.Text == DBnic)
                    {
                        con.Open();
                        SqlDataAdapter adapter1 = new SqlDataAdapter(retrievePI, con);
                        DataSet ds1 = new DataSet();
                        adapter1.Fill(ds1, "PersonalInfo");
                        dataGridView1.DataSource = ds1;
                        dataGridView1.DataMember = "PersonalInfo";

                        SqlDataAdapter adapter2 = new SqlDataAdapter(retrieveCI, con);
                        DataSet ds2 = new DataSet();
                        adapter2.Fill(ds2, "clinicalInfo");
                        dataGridView2.DataSource = ds2;
                        dataGridView2.DataMember = "clinicalInfo";
                        
                    }
                    if (searchBox.Text != DBnic)
                    {
                        MessageBox.Show("Patient Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }

                
            }
            catch (Exception er)
            {
                ErrorLog.SaveError(er.ToString());
                MessageBox.Show("ERROR: " + er.Message);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
