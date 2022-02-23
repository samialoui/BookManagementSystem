using BookManagementSystem.Classes;
using BookManagementSystem.UsersControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagementSystem.Forms
{
    public partial class AddNewBook : Form
    {
        public AddNewBook()
        {
            InitializeComponent();
        }
        Books book = new Books();
        UC_Purchase pc = new UC_Purchase();

        private void AddNewBook_Load(object sender, EventArgs e)
        {
           
            DataTable dt = book.Select();
           //dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(AddCategory ac = new AddCategory())
            {
                ac.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            long cost = long.Parse(textCost.Text);
            long sell = long.Parse(textSelling.Text);
            book.BookTitle = textBook.Text;
            book.Author = cmbAuth.Text;
            book.Quantity = textQnt.Text;
            book.Publisher = cmbPub.Text;
            book.Category = cmbCat.Text;
            book.CostPrice = cost;
            book.SellingPrice = sell;
            book.BarCode = textBar.Text;
            book.Remarks = textRem.Text;

            bool success = book.Insert(book);
            if(success == true)
            {
                MessageBox.Show("Added successfully"
                    );
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add the book, Try egain ...","Manque De Chose",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            }
           // DataTable dt = book.Select();
           // dataGridWiew1.DataSource = dt;
           
        }

      public void Clear()
        {
             textBook.Text="";
            cmbAuth.Text="";
             textQnt.Text = "";
             cmbPub.Text = "";
             cmbCat.Text = "";
            textCost.Text = "";
            textSelling.Text = "";
             textBar.Text = "";
            textRem.Text = "";
        }
    }
}
