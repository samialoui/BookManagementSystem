using BookManagementSystem.Classes;
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
    public partial class UC_Users : UserControl
    {
        public UC_Users()
        {
            InitializeComponent();
        }
        Users user = new Users();

        private void UC_Users_Load(object sender, EventArgs e)
        {
            DataTable dt = user.Select();
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.FirstName = textFirst.Text;
            user.LastName = textLast.Text;
            user.Phone = textPhone.Text;
            user.CNIC = textCnic.Text;
            user.Email = textEmail.Text;
            user.Password = textPassword.Text;
            user.Role = cmbRole.Text;

            bool success = user.Insert(user);
            if(success == true)
            {
                MessageBox.Show("User added successfully");
            }
            else
            {
                MessageBox.Show("User not Added !! try egain please..");
            }
            DataTable dt = user.Select();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear(); 
           
         }

        public void Clear()
        {
            textId.Text = "";
            textFirst.Text = "";
            textLast.Text = "";
            textCnic.Text = "";
            textEmail.Text = "";
            textPhone.Text = "";
            textPassword.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textId.Text);

            user.ID= id;
            bool success = user.Delete(user);
            if(success == true)
            {
                MessageBox.Show("User deleted successfully");
            }
            else
            {
                MessageBox.Show("User not deleted, Try egain...");
            }
            DataTable dt = user.Select();
            dataGridView1.DataSource = dt;
            Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textFirst.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textLast.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textPhone.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textCnic.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textEmail.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textPassword.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            cmbRole.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textId.Text);
            user.FirstName = textFirst.Text;
            user.LastName = textLast.Text;
            user.Phone = textPhone.Text;
            user.CNIC = textCnic.Text;
            user.Email = textEmail.Text;
            user.Password = textPassword.Text;
            user.Role = cmbRole.Text;
            user.ID = id;


            bool success = user.upDate(user);
            if(success == true)
            {
                MessageBox.Show("User upDated successfully");
            }
            else
            {
                MessageBox.Show("User not updated, Try egain please...");
            }

            DataTable dt = user.Select();
            dataGridView1.DataSource = dt;
            Clear();
        }

        static string mycnntrng = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string search = textSearch.Text;
            SqlConnection conn = new SqlConnection(mycnntrng);
            string sql = "SELECT * FROM tbl_Users WHERE FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%' OR Phone LIKE '%" + search + "%' OR CNIC LIKE '%" + search + "%' OR Email LIKE '%" + search + "%' OR Role LIKE '%" + search + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
