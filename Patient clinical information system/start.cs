using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_clinical_information_system
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }
        
        private void start_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

        }
        

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            LogInForm login = new LogInForm();
            this.Hide();
            login.Show();
        }

        private void PatientBtn_Click(object sender, EventArgs e)
        {
            SignInForm signin = new SignInForm();
            this.Hide();
            signin.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
