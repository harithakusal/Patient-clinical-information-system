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
    public partial class intro : Form
    {
        public intro()
        {
            InitializeComponent();
            timer1.Start(); //timer starts automatically because it is inside the constructor
        }
        

        private void intro_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            BackgroundImageLayout = ImageLayout.Stretch; //stretch background image to fit form
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.progressBar1.Increment(1);

            //if this is true timer stops and open next form
            if (progressBar1.Value == 100)
            {
                start st = new start();
                timer1.Stop();
                this.Hide();
                st.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
