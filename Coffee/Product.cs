using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Login form = new Login();
            form.Show();
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
              
           Double Esp , Capp, Espm, Mch, Amn, Late, Flw, Total, x1, x2, x3, x4, x5, x6, x7;

            x1 = float.Parse(txtEsp.Text);
            Esp = 100 ;

            x2 = float.Parse(txtCapp.Text);
            Capp = 120;

            x3 = float.Parse(txtEspm.Text);
            Espm = 100;

            x4 = float.Parse(txtMch.Text);
            Mch = 120;

            x5 = float.Parse(txtAmn.Text);
            Amn = 100;

            x6 = float.Parse(txtLate.Text);
            Late = 120;

            x7 = float.Parse(txtflw.Text);
            Flw = 100;

            Total = (x1 * Esp)+(x2 * Capp) + (x3 * Espm) + (x4 * Mch) + (x5 * Amn) + (x6 * Late) + (x7 * Flw);
            txtTotal.Text = Total.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double Total, Cash, Cashback;
            Total = float.Parse(txtTotal.Text);
            Cash = float.Parse(txtCash.Text);
            Cashback = Cash - Total;
            txtCashback.Text = Cashback.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtTotal.Clear();
            txtCash.Clear();
            txtCashback.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditUser form = new EditUser();

            form.Show();
        }
    }
}
