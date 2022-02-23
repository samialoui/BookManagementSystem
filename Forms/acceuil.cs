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
    public partial class acceuil : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public acceuil()
        {
            InitializeComponent();
            PanelWidth = PanelLeft.Width;
            timerTime.Start();
            isCollapsed = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                PanelLeft.Width = PanelLeft.Width + 10;
                if (PanelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }

            }
            else
            {
                PanelLeft.Width = PanelLeft.Width - 10;
                if (PanelLeft.Width <= 46)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelDate.Text = dt.ToString("HH:MM:ss");
        }

        private void AddControlToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            AddControlToPanel(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_Sales ucs = new UC_Sales();
            AddControlToPanel(ucs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_Purchase ucp = new UC_Purchase();
            AddControlToPanel(ucp);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UC_Users usr = new UC_Users();
            AddControlToPanel(usr);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}