using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace nguoiyeu
{
    public partial class BaucuaGame : Form
    {
        Image file;
        int TienCuoc = 0;

        public BaucuaGame()
        {
            InitializeComponent();
            napPicture();
            lbTienHienCo.Text = "100".ToString();
        }
        // nai , bau, ga , ca , cua ,tom
        int[] quayso = new int[3];
        int[] datcuoc = new int[6];

        string[] week = new string[7];
        
        public void napPicture()
        {
            week[0] = @"E:\nguoiyeu\nguoiyeu\nai.png";
            week[1] = @"E:\nguoiyeu\nguoiyeu\bau.png";
            week[2] = @"E:\nguoiyeu\nguoiyeu\ga.png";
            week[3] = @"E:\nguoiyeu\nguoiyeu\ca.png";
            week[4] = @"E:\nguoiyeu\nguoiyeu\cua.png";
            week[5] = @"E:\nguoiyeu\nguoiyeu\tom.png";
        }
        public void hieuung()
        {
            int stopLoop = 10;
            while (true)
            {
                Random rd1 = new Random();
                for (int i = 0; i < week.Length / 2; i++)
                {
                    // int numberrandown = rd1.Next(0, 2);

                    file = Image.FromFile(week[i]);
                    pictureBox1.Image = file;
                    file = Image.FromFile(week[i + 1]);
                    pictureBox2.Image = file;
                    file = Image.FromFile(week[i + 2]);
                    pictureBox3.Image = file;
                    Thread.Sleep(500);
                }
                stopLoop--;
                if (stopLoop == 0) break;

            }
        }
        public int TongTienCuoc()
        {
            TienCuoc = (int)(Numbau.Value + NumCa.Value + Numtom.Value + numNai.Value + Numga.Value + Numcua.Value);
            return TienCuoc;
        }
        public int TienThang(NumericUpDown nai, NumericUpDown bau, NumericUpDown ga, NumericUpDown ca, NumericUpDown cua, NumericUpDown tom,int []quayso)
        {
            int TienThuong = 0;
            if (nai.Value > 0) datcuoc[0] = (int)nai.Value;
            if (bau.Value > 0) datcuoc[1] = (int)bau.Value;
            if (ga.Value > 0) datcuoc[2] = (int)ga.Value;
            if (ca.Value > 0) datcuoc[3] = (int)ca.Value;
            if (cua.Value > 0) datcuoc[4] = (int)cua.Value;
            if (tom.Value > 0) datcuoc[5] = (int)tom.Value;
            for(int t=0; t<quayso.Length; t++)
                for( int index =0; index < datcuoc.Length; index++)
                {
                    if(quayso[t]==index && datcuoc[quayso[t]] > 0) { TienThuong += datcuoc[index]; }
                }
            return TienThuong;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(numNai.Value==0 && Numga.Value == 0 && NumCa.Value == 0 && Numtom.Value == 0 && Numcua.Value == 0 && Numbau.Value == 0 ) 
            {
                MessageBox.Show("Ban Chua Dat cuoc ");
            }
            else

            {
               
                Random rd = new Random();
                for (int i = 0; i < quayso.Length; i++)
                {
                    quayso[i] = rd.Next(0, 6);
                }
               
                file = Image.FromFile(week[quayso[0]]);
                pictureBox1.Image = file;
                file = Image.FromFile(week[quayso[1]]);
                pictureBox2.Image = file;
                file = Image.FromFile(week[quayso[2]]);
                pictureBox3.Image = file;
                int tienthang = (int)TienThang(numNai, Numbau, Numga, NumCa, Numcua, Numtom, quayso);
                int Tienhientai = int.Parse(lbTienHienCo.Text);
                Tienhientai = Tienhientai + (2*tienthang - TongTienCuoc());
                lbTienHienCo.Text=Tienhientai.ToString();
                lbtrutien.Text=(2*tienthang-TongTienCuoc()).ToString();   


            }
            
           
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            file = Image.FromFile(@"E:\nguoiyeu\nguoiyeu\images.jpeg");
            pictureBox1.Image = file;
            pictureBox2.Image = file;
            pictureBox3.Image = file;

        }

        private void picNai_Click(object sender, EventArgs e)
        {
            numNai.UpButton();
        }

        private void PicBau_Click(object sender, EventArgs e)
        {
            Numbau.UpButton();
        }

        private void PicGa_Click(object sender, EventArgs e)
        {
            Numga.UpButton();
        }

        private void Picca_Click(object sender, EventArgs e)
        {
            NumCa.UpButton();
        }

        private void PicCua_Click(object sender, EventArgs e)
        {
            Numcua.UpButton();
        }

        private void Pictom_Click(object sender, EventArgs e)
        {
            Numtom.UpButton();
        }
    }
    }
    