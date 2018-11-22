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
    public partial class Personal_Info : Form
    {
        public Personal_Info()
        {
            InitializeComponent();
        }

        private void Personal_Info_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(fullname.Text != "" && nic.Text != "" && email.Text != "" && address.Text != "" && phone.Text != "" && batch.Text != "" && studentID.Text != "" && dob.Text != "")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(SignInForm.myConnection))
                    {
                        con.Open();

                        string personal_details = "INSERT INTO PersonalInfo VALUES('" + (nic.Text) + "','" + (fullname.Text) + "','" + (address.Text) + "','" + (phone.Text) + "','" + (email.Text) + "','" + (DateTime.Parse(dob.Text)) + "','" + (batch.Text) + "','" + (studentID.Text) + "'); ";

                        SqlCommand command = new SqlCommand(personal_details,con);
                        command.ExecuteNonQuery();

                        Clinical_Info c = new Clinical_Info();
                        this.Hide();
                        c.Show();
                    }
                }
                catch(Exception ex)
                {
                    ErrorLog.SaveError("ERROR : " + ex.ToString());
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("All the fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LogInForm l = new LogInForm();
            l.Show();
        }
    }
}
