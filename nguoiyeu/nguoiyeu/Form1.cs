using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nguoiyeu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.monthCalendar1.MaxDate = DateTime.Today.AddYears(0);
            this.monthCalendar1.MinDate = DateTime.Now.AddYears(-100);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int s = int.Parse(label1.Text);
            label1.Text = (s - 1).ToString();
            if (s == 1) 
                {
                timer1.Stop();
                MessageBox.Show("Gaaaaaaaa");
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
