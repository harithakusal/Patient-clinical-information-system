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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public static string myConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Coding projects\C#\PCIS v1\Patient clinical information system\Patient clinical information system\PCIS_Database.mdf;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {
            //executes when username or new password or confirm password boxes are empty
            if (SignInUsernameBox.Text == "" || SignInNewpasswordBox.Text == "" || SignInConfirmpasswordBox.Text == "")
            {
                MessageBox.Show("All the fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto HERE;
            }

            //executes when new password box doesn't match confirm password box
            if(SignInNewpasswordBox.Text != SignInConfirmpasswordBox.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto HERE;
            }

            //creating DB connection
            using (SqlConnection con = new SqlConnection(myConnection))
            {
                con.Open(); //opening DB connection

                //count records which have the same username as the username box of sign in form
                string check = "SELECT COUNT(*) FROM SignInInfo WHERE username = '" + SignInUsernameBox.Text + "';";
                
                try
                {
                    //send commands to db
                    SqlCommand command1 = new SqlCommand(check, con);
                    int count = Convert.ToInt32(command1.ExecuteScalar()); //execute scalar is used with aggregate functions in SQL 

                    if (count != 0) 
                    {
                        SignInForm s = new SignInForm();
                        s.usernameTaken();

                        goto HERE;
                    }

                    //insert username and confirm password to SignInInfo table
                    string InsertAccDetails = "INSERT INTO SignInInfo VALUES('" + (SignInUsernameBox.Text) + "','" + (SignInConfirmpasswordBox.Text) + "');";

                    SqlCommand command = new SqlCommand(InsertAccDetails, con);   
                    command.ExecuteNonQuery(); //use to command DB (except SELECT)
                }
                catch(Exception ex)
                {
                    ErrorLog.SaveError("ERROR : " + ex.ToString()); //send error to log file through ErrorLog class
                    MessageBox.Show(ex.Message);
                }
            }

            //executes when username,newpassword and confirmpassword not empty and new password is as same as confirm password
            if ((SignInUsernameBox.Text != "") && (SignInNewpasswordBox.Text != "") && (SignInConfirmpasswordBox.Text != "") && (SignInNewpasswordBox.Text == SignInConfirmpasswordBox.Text))
            {        
                Personal_Info p = new Personal_Info();
                MessageBox.Show("Account Creation Successfull", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                p.Show();

            }
            else
            {
                MessageBox.Show("Invalid try", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        HERE:
            return;

        }

        void usernameTaken()
        {
            MessageBox.Show("This username is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            start s = new start();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignInConfirmpasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogInForm l = new LogInForm();
            this.Close();
            l.Show();
        }
    }
}
