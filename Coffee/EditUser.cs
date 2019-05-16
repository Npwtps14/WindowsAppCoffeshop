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
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
        }
        #region
        SqlConnection cn; SqlCommand com;
        SqlDataReader dr; DataTable dt;

        private void LoadData()
        {
            string sql = @"Show_User";//เปลี่ยนชื่อใน Stored
            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = sql;
            com.Connection = cn;
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dt = new DataTable(); dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            dr.Close();

            dataGridView1.AutoGenerateColumns = false;
        }
        #endregion


        private void EditUser_Load(object sender, EventArgs e)
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
            textBox1.Enabled = false;
            this.LoadData();



        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"Mem_Edit";
            com = new SqlCommand(); com.CommandText = sql;
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = cn; com.Parameters.Clear();
            com.Parameters.Add("@Passwd", SqlDbType.VarChar).Value = textBox2.Text.Trim();
            com.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text.Trim();

            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dt = new DataTable(); dt.Load(dr);
                this.LoadData();

                Login form = new Login();
                form.Show();


            }
            else
            {
                this.Hide();
                Product form = new Product();
                form.Show();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
