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

namespace BookManagementSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static string myCon = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(myCon);
            string sql = "SELECT COUNT(*) FROM tbl_Login WHERE username = '" + textUser.Text + "' And  password = '" + textPass.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") {
                MessageBox.Show("Connexion Successfully", "Success Login");
                this.Hide();
                using (acceuil ac = new acceuil())
                {
                    ac.ShowDialog();
                }
              

            }
            else
            {
                MessageBox.Show("Please check your login and password ...", "Error Login",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
