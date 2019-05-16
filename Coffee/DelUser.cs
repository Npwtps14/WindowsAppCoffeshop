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
    public partial class DelUser : Form
    {
        public DelUser()
        {
            InitializeComponent();
        }
        #region
        SqlConnection cn; SqlCommand com; SqlTransaction tr; DataTable dt;

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

        private void DelUser_Load(object sender, EventArgs e)
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
            this.LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"Mem_Del";//เปลี่ยนชื่อใน Stored
            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = sql;
            com.Connection = cn;
            com.Transaction = tr;
            com.Parameters.Clear();
            com.Parameters.Add("@Username", SqlDbType.VarChar).Value =textBox1.Text.Trim();

            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dt = new DataTable(); dt.Load(dr);
                dataGridView1.DataSource = dt;
               
                this.LoadData();
               
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            dr.Close();

            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DelUser form = new DelUser();
            form.Show();


        }
    }
}
