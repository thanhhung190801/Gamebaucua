using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Layout;

namespace nguoiyeu
{
    public partial class ThiTracNghiem : Form
    {
        public ThiTracNghiem()
        {
            InitializeComponent();
        }
     
        private int _thoigianthi;
        public int thoigianthi
        {
            get { return _thoigianthi; }
            set { _thoigianthi = value; }
        }
        ArrayList l;
        int vt = 0;
        public int giay =10;
        public int phut = 1;
        private void thi2_Load(object sender, EventArgs e)
        {
            readQuestions d = new readQuestions();
            l = d.docFile();
           loadQ(0);
           loadNut();
            
            lbgiay.Text = giay.ToString();
            lbphut.Text = phut.ToString();
            timer1.Start();
        }
        private void loadQ(int i)
        {
            cauhoi c = (cauhoi)l[i];
            lblQ1.Text = c.content;
            A1.Text = c.A;
            B1.Text = c.B;
            C1.Text = c.C;
            D1.Text = c.D;
            A1.Checked = B1.Checked = C1.Checked = D1.Checked = false;
            if (c.answer == 0) A1.Checked = true;
            if (c.answer == 1) B1.Checked = true;
            if (c.answer == 2) C1.Checked = true;
            if (c.answer == 3) D1.Checked = true;
            if (i == 0)
                this.btPrevious.Enabled = false;
            else
                this.btPrevious.Enabled = true;
            if (i == this.l.Count - 1)
                this.btNext.Enabled = false;
            else
                this.btNext.Enabled = true;
            this.vt = i;
            this.lblA.BackColor = this.lblB.BackColor = this.lblC.BackColor = this.lblD.BackColor = Color.Empty;
            if (this.btnNopBai.Enabled)
                return;
            if (((cauhoi)this.l[this.vt]).answer == 0)
                this.lblA.BackColor = Color.Blue;
            if (((cauhoi)this.l[this.vt]).answer == 1)
                this.lblB.BackColor = Color.Blue;
            if (((cauhoi)this.l[this.vt]).answer == 2)
                this.lblC.BackColor = Color.Blue;
            if (((cauhoi)this.l[this.vt]).answer == 3)
                this.lblD.BackColor = Color.Blue;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            remember();
            vt++;
            loadQ(vt);
            this.loadQ(this.vt);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            remember();
            vt--;
            loadQ(vt);
            this.loadQ(this.vt);
        }
        private void remember()
        {
            ((cauhoi) this.l[this.vt]).answer = this.A1.Checked ? 0:(this.B1.Checked ? 1 : (this.C1.Checked ? 2 : (this.D1.Checked ? 3:-1)));
            if (!this.A1.Checked && !this.B1.Checked && !this.C1.Checked && !this.D1.Checked)
                return;
            foreach (Control control in (ArrangedElementCollection)this.panel1.Controls)
            {
                if (control.Name == ((this.vt + 1).ToString() ?? "") && control.BackColor != Color.Yellow)
                    control.BackColor = Color.Blue;
            }
        }
        private void loadNut()
        {
            int num1 = 0;
            int num2 = 0;
            for (int index = 0; index < this.l.Count; ++index)
            {
                Button button1 = new Button();
                Button button2 = button1;
                int num3 = index + 1;
                string str1 = num3.ToString() ?? "";
                button2.Text = str1;
                button1.Size = new Size(50, 50);
                button1.Location = new Point(13 + num1 * 50, 13 + num2 * 50);
                Button button3 = button1;
                num3 = index + 1;
                string str2 = num3.ToString() ?? "";
                button3.Name = str2;
                ++num1;
                if (num1 == 3)
                {
                    num1 = 0;
                    ++num2;
                }
                button1.Click += new EventHandler(this.chon_Click);
                this.panel1.Controls.Add((Control)button1);
            }
        }
        private void chon_Click(object sender, EventArgs e)
        {
            this.remember();
            this.loadQ(int.Parse(((Control)sender).Text) - 1);
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            this.remember();
            int num = 0;
            for (int index = 0; index < this.l.Count; ++index)
            {
                cauhoi cauHoi = (cauhoi)this.l[index];
                if (cauHoi.result == cauHoi.answer)
                    ++num;
            }
            this.lblketQua.Text = num.ToString() + "/" + this.l.Count.ToString();
            this.btnNopBai.Enabled = false;
            this.btnNghiNgo.Enabled = false;
            this.btnChacChan.Enabled = false;
        }

        private void btnChacChan_Click_1(object sender, EventArgs e)
        {
            if (!this.A1.Checked && !this.B1.Checked && !this.C1.Checked && !this.D1.Checked)
                return;
            foreach (Control control in (ArrangedElementCollection)this.panel1.Controls)
            {
                if (control.Name == ((this.vt + 1).ToString() ?? ""))
                    control.BackColor = Color.Blue;
            }
        }

        private void btnNghiNgo_Click(object sender, EventArgs e)
        {
            if (!this.A1.Checked && !this.B1.Checked && !this.C1.Checked && !this.D1.Checked)
                return;
            foreach (Control control in (ArrangedElementCollection)this.panel1.Controls)
            {
                if (control.Name == ((this.vt + 1).ToString() ?? ""))
                    control.BackColor = Color.Yellow;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            giay = giay - 1;
            lbgiay.Text = giay.ToString();
            if (giay == 0)
            {
                phut = phut - 1;
                lbphut.Text = phut.ToString();
                giay = 60;
               
            }
            if (phut == 0 && giay == 1)
            {
                lbgiay.Text = 0.ToString();
                timer1.Stop();
                MessageBox.Show("Hết thời gian làm bài.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lbphut.Text = "00";
                lbgiay.Text = "00";
                btnNopBai_Click(sender, e);
            }
        }
    }
}
