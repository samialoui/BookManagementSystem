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
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        Random rand = new Random();
        private void LoadChart()
        {
            var cnv = new Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.Canvas();
            var dataPoint = new Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced._type.Bunifu_splineArea);

            dataPoint.addLabely("Jan", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Feb", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Mar", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Apr", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Jun", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Jul", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Aug", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Sup", rand.Next(0, 500).ToString());
            dataPoint.addLabely("Oct", rand.Next(0, 500).ToString());

            cnv.addData(dataPoint);
            bunifuDatavizAdvanced1.colorSet.Add(Color.Red);
            bunifuDatavizAdvanced1.Render(cnv);
      
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
