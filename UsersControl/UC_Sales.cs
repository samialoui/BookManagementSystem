using BookManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagementSystem.UsersControl
{
    public partial class UC_Sales : UserControl
    {
        public UC_Sales()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(FormFinish ff = new FormFinish())
            {
                ff.ShowDialog();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void UC_Sales_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using(FormFinish ff = new FormFinish())
            {
                ff.ShowDialog();
            }
        }
    }
}
