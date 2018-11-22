using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Patient_clinical_information_system
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //executes when username or password is empty
            if ((LogInUsernameBox.Text == "" && LogInPasswordBox.Text == "") || (LogInUsernameBox.Text == "" || LogInPasswordBox.Text == ""))
            {
                MessageBox.Show("All the fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto HERE;
            }

            //sql command to select all from signInInfo table where username and passwords are equal to their corresponding textboxes
            string retrieveInfo = "SELECT * FROM SignInInfo WHERE username='"+LogInUsernameBox.Text+"' AND password='"+LogInPasswordBox.Text+"';";

            //create conection
            using (SqlConnection con = new SqlConnection(SignInForm.myConnection))
            {
                try
                {
                    //open connection
                    con.Open();

                    //Command db
                    SqlCommand command = new SqlCommand(retrieveInfo, con);
                    SqlDataReader reader = command.ExecuteReader(); //read records from table
                    while (reader.Read()) // iterate while reading all the records
                    {
                        string DBusername = reader["username"].ToString(); //assign read username to a var 
                        string DBpassword = reader["password"].ToString(); //assign read password to a var

                        //executes when username var equal to usernamebox and password var to password box
                        if (DBusername == LogInUsernameBox.Text && DBpassword == LogInPasswordBox.Text)
                        {
                            MessageBox.Show("Login Successfull", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            searchForm s = new searchForm();
                            s.Show();
                            this.Hide();
                            break; //terminates the loop
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError("ERROR : " + ex.ToString()); //send error to log file
                    MessageBox.Show(ex.Message);
                }
            }

        HERE:
            return;
        }
    }
}
