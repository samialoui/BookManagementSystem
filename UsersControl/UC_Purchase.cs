using BookManagementSystem.Classes;
using BookManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagementSystem.UsersControl
{
    public partial class UC_Purchase : UserControl
    {
        public UC_Purchase()
        {
            InitializeComponent();
        }
        Books Book = new Books();
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(AddNewBook nb = new AddNewBook())
            {
                nb.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(AddStock AS = new AddStock())
            {
                AS.ShowDialog(); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_Purchase_Load(object sender, EventArgs e)
        {
            DataTable dt = Book.Select();
            dataGridView1.DataSource = dt;
        }

        static string myCon = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string search = textSearch.Text;
            SqlConnection con = new SqlConnection(myCon);
            if(cmbSearch.Text =="Tracking ID")
            {
                string sql = "SELECT * FROM tbl_Books WHERE Id LIKE '%" + search + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if(cmbSearch.Text == "Book Title")
            {
                string sql1 = "SELECT * FROM tbl_Books WHERE BookTitle LIKE '%" + search + "%'";
                SqlDataAdapter sda1 = new SqlDataAdapter(sql1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            else if (cmbSearch.Text == "Author")
            {
                string sql1 = "SELECT * FROM tbl_Books WHERE Author LIKE '%" + search + "%'";
                SqlDataAdapter sda1 = new SqlDataAdapter(sql1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            else if (cmbSearch.Text == "Publisher")
            {
                string sql1 = "SELECT * FROM tbl_Books WHERE Publisher LIKE '%" + search + "%'";
                SqlDataAdapter sda1 = new SqlDataAdapter(sql1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            else 
            {
                string sql1 = "SELECT * FROM tbl_Books WHERE Quantity LIKE '%" + search + "%'";
                SqlDataAdapter sda1 = new SqlDataAdapter(sql1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }

        }
    }
}
