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

namespace Coffee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection cn; SqlCommand com;
        SqlDataReader dr; DataTable dt;
        private void Login_Load(object sender, EventArgs e)
        {
            string strConn;
            strConn = dbcon.DB;
            cn = new SqlConnection();
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.ConnectionString = strConn;

            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"Mem_Login";
            com = new SqlCommand(); com.CommandText = sql;
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = cn; com.Parameters.Clear();
            com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
            com.Parameters.Add("@Passwd", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dt = new DataTable(); dt.Load(dr);
                this.Hide();
                Product form = new Product();
                form.Show();

              

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้ ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           





        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear();
           
            textBox1.Focus();
        }

        private void forADMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin form = new Admin();
            form.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register form = new Register();
            form.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

