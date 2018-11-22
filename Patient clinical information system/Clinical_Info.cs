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
    public partial class Clinical_Info : Form
    {
        public Clinical_Info()
        {
            InitializeComponent();
        }

        private void Clinical_Info_Load(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Personal_Info p = new Personal_Info();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string A = (a.Checked) ? "Yes" : "No";
            string B = (b.Checked) ? "Yes" : "No";
            string C = (c.Checked) ? "Yes" : "No";
            string D = (d.Checked) ? "Yes" : "No";
            string E = (er.Checked) ? "Yes" : "No"; // "er" is used, because in method signature "e" was already used as a parameter
            string F = (f.Checked) ? "Yes" : "No";
            string G = (g.Checked) ? "Yes" : "No";
            string H = (h.Checked) ? "Yes" : "No";
            string I = (i.Checked) ? "Yes" : "No";
            string J = (j.Checked) ? "Yes" : "No";
            string K = (k.Checked) ? "Yes" : "No";
            string L = (l.Checked) ? "Yes" : "No";
            string M = (m.Checked) ? "Yes" : "No";
            string N = (n.Checked) ? "Yes" : "No";
            string O = (o.Checked) ? "Yes" : "No";
            string P = (p.Checked) ? "Yes" : "No";
            string Q = (q.Checked) ? "Yes" : "No";
            string R = (r.Checked) ? "Yes" : "No";

            string InsertClinicalInfo = "INSERT INTO clinicalInfo VALUES('" + nic.Text + "','" + A + "','" + B + "','" + C + "','" + D + "','" + E + "','" + F + "','" + G + "','" + H + "','" + I + "','" + J + "','" + K + "','" + L + "','" + M + "','" + N + "','" + O + "','" + P + "','" + Q + "','" + R + "','" + detailBox1.Text + "','" + detailBox2.Text + "');";

            try
            {
                using (SqlConnection con = new SqlConnection(SignInForm.myConnection))
                {
                    con.Open();

                    SqlCommand com = new SqlCommand(InsertClinicalInfo, con);
                    com.ExecuteNonQuery();
                    
                    this.Close();
                    start st = new start();
                    st.Show();
                }
            }
            catch(Exception e1)
            {
                ErrorLog.SaveError("ERROR : " + e1.ToString());
                MessageBox.Show(e1.Message);
            }
        }

        private void a_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void nic_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
