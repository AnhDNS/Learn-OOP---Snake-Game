using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Snake
{
    public partial class Form1 : Form
    {
        Point Toado;
        Point Toadoran;
        Point Toado1;
        Point Toadoran1;

        Giaiphongdulieu giaiphongdulieu;
        VatCan vatcan;
        ThucAn thucan;
        TaoBoss taoboss;
        XetVaCham vacham;

        int diem = 0;
        int diemcao = 0;
        int phut = 1;
        int giay = 59;
        Random rd;
        bool U = false;
        bool D = false;
        bool L = false;
        bool R = true;

        PictureBox daucuaconran;

        public Form1()
        {
            InitializeComponent();
        }
        List<PictureBox> daunhungconran = new List<PictureBox>();
        List<PictureBox> thancuaconran = new List<PictureBox>();
        List<PictureBox> thancuaconran1 = new List<PictureBox>();
        List<PictureBox> listthucan = new List<PictureBox>();
        List<PictureBox> tuong = new List<PictureBox>();

        

        private void taopicturebox(int a,int b,int c, int d,PictureBox e,Panel f,List<PictureBox> g)
        {
            e.Width = a;
            e.Height = b;
            e.Left = c;
            e.Top = d;
            e.BackgroundImage = Properties.Resources.jkljlkj;
            e.BackgroundImageLayout = ImageLayout.Stretch;
            g.Add(e);
            f.Controls.Add(e);
        }
        void load()
        {
            // Tạo ra đầu con rắn do mình điều khiển và 1 phần đuôi
            PictureBox daucuaconran = new PictureBox();
            taopicturebox(10, 10, 20, 20, daucuaconran, panel1, daunhungconran);
            PictureBox than = new PictureBox();
            taopicturebox(10, 10, daunhungconran[0].Left - 10, daunhungconran[0].Top, than, panel1, thancuaconran);
            Dongho.Start();
            phut = 1;
            giay = 59;
            button2.Enabled = true;
            startBtn.Enabled = false;
        }
        private void Dichuyendauconran_Tick(object sender, EventArgs e)
        {
            // Lấy tọa độ đầu
            Toado = new Point(daunhungconran[0].Location.X, daunhungconran[0].Location.Y);
            
            // Đường đi của con rắn do mình điều khiển
            if (U == true)
            {
                daunhungconran[0].Top -= 10;
            }
            else if (D == true)
            {
                daunhungconran[0].Top += 10;
            }
            else if (L == true)
            {
                daunhungconran[0].Left -= 10;
            }
            else
            {
                daunhungconran[0].Left += 10;
            }

            //var myPlayer = new System.Media.SoundPlayer();
            //myPlayer.SoundLocation = @"E:\data\051.wav";
            //myPlayer.Play();
            // Phần thân kết nối với đầu con rắn
            
            for (int i = thancuaconran.Count - 1; i > 0; i--)
            {
                Toadoran = new Point(thancuaconran[i - 1].Location.X, thancuaconran[i - 1].Location.Y);
                thancuaconran[i].Location = Toadoran;
            }
            thancuaconran[0].Location = Toado;
          
           
        }
        private void Thancuaconran_Tick(object sender, EventArgs e)
        {
            PictureBox than = new PictureBox();
            taopicturebox(10, 10, thancuaconran[0].Left, thancuaconran[0].Top, than, panel1, thancuaconran);
            Thancuaconran.Stop();
        }
        private void Thancuaconrankydihukhong_Tick(object sender, EventArgs e)
        {
            PictureBox than = new PictureBox();
            taopicturebox(10, 10, thancuaconran1[0].Left, thancuaconran1[0].Top, than, panel1, thancuaconran1);
            Thancuaconrankydihukhong.Stop();
        }

        private void Anmoi_Tick(object sender, EventArgs e)
        {
            if (listthucan[0].Location == daunhungconran[0].Location)
            {
                panel1.Controls.Remove(listthucan[0]);
                listthucan.RemoveAt(0);
                if (comboBox1.Text == "Mê Cung")
                {
                    thucan = new ThucAn();
                    thucan.TaoThucAn(panel1, listthucan);
                }
                else
                {
                    thucan = new ThucAn();
                    thucan.TaoThucAn2(panel1, listthucan);
                }
                diem++;
                //var myPlayer = new System.Media.SoundPlayer();
                //myPlayer.SoundLocation = @"E:\data\m_cancel.wav";
                //myPlayer.Play();
                giay += 4;
                label2.Text = diem.ToString();
                Thancuaconran.Start();
            }
            if (comboBox1.Text == "Đại Chiến")
            {
                if (listthucan[0].Location == daunhungconran[1].Location || listthucan[0].Location == daunhungconran[2].Location || listthucan[0].Location == daunhungconran[3].Location)
                {
                    panel1.Controls.Remove(listthucan[0]);
                    listthucan.RemoveAt(0);
                    thucan = new ThucAn();
                    thucan.TaoThucAn1(panel1, listthucan);
                }
            }  
            else if(comboBox1.Text == "Kỳ Dị Hư Không")
            {
                if (listthucan[0].Location == daunhungconran[1].Location)
                {
                    panel1.Controls.Remove(listthucan[0]);
                    listthucan.RemoveAt(0);
                    thucan = new ThucAn();
                    thucan.TaoThucAn2(panel1, listthucan);
                    Thancuaconrankydihukhong.Start();
                }
            }

        }

        private void Dieukhiendau3conran_Tick(object sender, EventArgs e)
        {
            taoboss = new TaoBoss();
            taoboss.Dieukhiendau3conran(daunhungconran, listthucan);            
        }

        private void Rantieudietnhau_Tick(object sender, EventArgs e)
        {
            taoboss = new TaoBoss();
            if (taoboss.Rantieudietnhau(daunhungconran, thancuaconran) == true)
            {
                Dichuyendauconran.Stop();
                Anmoi.Stop();
                Thancuaconran.Stop();
                Dieukhiendau3conran.Stop();
                Rantieudietnhau.Stop();  
                Panel_Paint.Stop();
                if (diem > diemcao)
                    diemcao = diem;
                label5.Text = diemcao.ToString();
                startBtn.Enabled = true;
                button2.Enabled = false;
                Dongho.Stop();
                Dongho.Stop();
                //var myPlayer = new System.Media.SoundPlayer();
                //myPlayer.SoundLocation = @"E:\data\004.wav";
                //myPlayer.Play();
                MessageBox.Show("Điểm của bạn là : " + diem.ToString());
                 //var myPlayer1 = new System.Media.SoundPlayer();
                 //myPlayer1.SoundLocation = @"E:\data\m_end.wav";
                //myPlayer1.Play();              
                MessageBox.Show("Bạn đã die cho chạm đầu với thằng đỏ !!!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Focus();
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up && D == false)
            {
                U = true;
                D = false;
                L = false;
                R = false;
            }
            else if (e.KeyCode == Keys.Down && U == false)
            {
                U = false;
                D = true;
                L = false;
                R = false;
            }
            else if (e.KeyCode == Keys.Left && R == false)
            {
                U = false;
                D = false;
                L = true;
                R = false;
            }
            else if (e.KeyCode == Keys.Right && L == false)
            {
                U = false;
                D = false;
                L = false;
                R = true;
            }
            if (e.KeyCode == Keys.P && button2.Enabled == true)
            {

                Dichuyendauconran.Stop();
                Anmoi.Stop();
                Thancuaconran.Stop();
                Dongho.Stop();
                if (comboBox1.Text == "Đại Chiến")
                {
                    Dieukhiendau3conran.Stop();
                    Rantieudietnhau.Stop();
                }
                else if (comboBox1.Text == "Kỳ Dị Hư Không")
                {
                    Dieukhienrankidihukhong.Stop();
                    Khonggianhukhong.Stop();
                }
                button2.Text = "Tiếp Tục";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giaiphong();
            batdaugame();
            label2.Text = diem.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Hướng_Dẫn a = new Hướng_Dẫn();
            a.Show();
            
            //var myPlayer = new System.Media.SoundPlayer();
            //myPlayer.SoundLocation = @"E:\data\016.wav";
            //myPlayer.Play();
        }

        private void Dieukhienrankidihukhong_Tick(object sender, EventArgs e)
        {
            taoboss = new TaoBoss();
            Toado1 = new Point(daunhungconran[1].Location.X, daunhungconran[1].Location.Y);
            if (taoboss.bosskidihukhong(daunhungconran[1], listthucan, thancuaconran) == true)
            {
                giaiphongdulieu = new Giaiphongdulieu();
                giaiphongdulieu.giaiphong(thancuaconran1, panel1);
                PictureBox than = new PictureBox();
                taopicturebox(10, 10, daunhungconran[1].Left + 10, daunhungconran[1].Top, than, panel1, thancuaconran1);
            }
            for (int j = thancuaconran1.Count - 1; j > 0; j--)
            {
                Toadoran1 = new Point(thancuaconran1[j - 1].Location.X, thancuaconran1[j - 1].Location.Y);
                thancuaconran1[j].Location = Toadoran1;
            }
            thancuaconran1[0].Location = Toado1;         
        }

        private void Khonggianhukhong_Tick(object sender, EventArgs e)
        {
            int t;
            rd = new Random();
            t = rd.Next(1,4);
            if (daunhungconran[0].Location == daunhungconran[2].Location)
            {
                if (t == 1)
                {
                    daunhungconran[0].Left = daunhungconran[3].Left;
                    daunhungconran[0].Top = daunhungconran[3].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else if (t == 2)
                {
                    daunhungconran[0].Left = daunhungconran[3].Left;
                    daunhungconran[0].Top = daunhungconran[3].Top + 10;
                    U = false;
                    D = true;
                    L = false;
                    R = false;
                }
                else if (t == 3)
                {
                    daunhungconran[0].Left = daunhungconran[3].Left - 10;
                    daunhungconran[0].Top = daunhungconran[3].Top;
                    U = false;
                    D = false;
                    L = true;
                    R = false;
                }
                else
                {
                    daunhungconran[0].Left = daunhungconran[3].Left + 10;
                    daunhungconran[0].Top = daunhungconran[3].Top;
                    U = false;
                    D = false;
                    L = false;
                    R = true;
                }
            }
            if (daunhungconran[0].Location == daunhungconran[3].Location)
            {
                if (t == 1)
                {
                    daunhungconran[0].Left = daunhungconran[2].Left;
                    daunhungconran[0].Top = daunhungconran[2].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else if (t == 2)
                {
                    daunhungconran[0].Left = daunhungconran[2].Left;
                    daunhungconran[0].Top = daunhungconran[2].Top + 10;
                    U = false;
                    D = true;
                    L = false;
                    R = false;
                }
                else if (t == 3)
                {
                    daunhungconran[0].Left = daunhungconran[2].Left - 10;
                    daunhungconran[0].Top = daunhungconran[2].Top;
                    U = false;
                    D = false;
                    L = true;
                    R = false;
                }
                else
                {
                    daunhungconran[0].Left = daunhungconran[2].Left + 10;
                    daunhungconran[0].Top = daunhungconran[2].Top;
                    U = false;
                    D = false;
                    L = false;
                    R = true;
                }
            }
            if (daunhungconran[0].Location == daunhungconran[4].Location)
            {
                if (t == 1)
                {
                    daunhungconran[0].Left = daunhungconran[5].Left;
                    daunhungconran[0].Top = daunhungconran[5].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else if (t == 2)
                {
                    daunhungconran[0].Left = daunhungconran[5].Left;
                    daunhungconran[0].Top = daunhungconran[5].Top + 10;
                    U = false;
                    D = true;
                    L = false;
                    R = false;
                }
                else if (t == 3)
                {
                    daunhungconran[0].Left = daunhungconran[5].Left - 10;
                    daunhungconran[0].Top = daunhungconran[5].Top;
                    U = false;
                    D = false;
                    L = true;
                    R = false;
                }
                else
                {
                    daunhungconran[0].Left = daunhungconran[5].Left + 10;
                    daunhungconran[0].Top = daunhungconran[5].Top;
                    U = false;
                    D = false;
                    L = false;
                    R = true;
                }
            }
            if (daunhungconran[0].Location == daunhungconran[5].Location)
            {
                if (t == 1)
                {
                    daunhungconran[0].Left = daunhungconran[4].Left;
                    daunhungconran[0].Top = daunhungconran[4].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else if (t == 2)
                {
                    daunhungconran[0].Left = daunhungconran[4].Left;
                    daunhungconran[0].Top = daunhungconran[4].Top + 10;
                    U = false;
                    D = true;
                    L = false;
                    R = false;
                }
                else if (t == 3)
                {
                    daunhungconran[0].Left = daunhungconran[4].Left - 10;
                    daunhungconran[0].Top = daunhungconran[4].Top;
                    U = false;
                    D = false;
                    L = true;
                    R = false;
                }
                else
                {
                    daunhungconran[0].Left = daunhungconran[4].Left + 10;
                    daunhungconran[0].Top = daunhungconran[4].Top;
                    U = false;
                    D = false;
                    L = false;
                    R = true;
                }
            }
            if (daunhungconran[0].Location == daunhungconran[6].Location)
            {
                if (t == 1)
                {
                    daunhungconran[0].Left = daunhungconran[2].Left;
                    daunhungconran[0].Top = daunhungconran[2].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else if (t == 2)
                {
                    daunhungconran[0].Left = daunhungconran[2].Left - 10;
                    daunhungconran[0].Top = daunhungconran[2].Top;
                    U = false;
                    D = false;
                    L = true;
                    R = false;
                }
                else if (t == 3)
                {
                    daunhungconran[0].Left = daunhungconran[5].Left;
                    daunhungconran[0].Top = daunhungconran[5].Top - 10;
                    U = true;
                    D = false;
                    L = false;
                    R = false;
                }
                else
                {
                    daunhungconran[0].Left = daunhungconran[5].Left + 10;
                    daunhungconran[0].Top = daunhungconran[5].Top;
                    U = false;
                    D = false;
                    L = false;
                    R = true;
                }
            }
        }
        
        private void Panel_Paint_Tick(object sender, EventArgs e)
        {
            // Không cho rắn ra ngoài.
            if (daunhungconran[0].Left > 490)
                daunhungconran[0].Left = 0;
            if (daunhungconran[0].Top > 490)
                daunhungconran[0].Top = 0;
            if (daunhungconran[0].Left < 0)
                daunhungconran[0].Left = 490;
            if (daunhungconran[0].Top < 0)
                daunhungconran[0].Top = 490;
            // Kết thúc không cho rắn ra ngoài.
            // Xét va chạm
            vacham = new XetVaCham();
            if (vacham.kiemtravacham(daunhungconran, thancuaconran) == true)
            {
                die(@"E:\data\004.wav");
                //var myPlayer = new System.Media.SoundPlayer();
                //myPlayer.SoundLocation = @"E:\data\m_end.wav";
                //myPlayer.Play();
                MessageBox.Show("Bạn đã die do đâm đầu vào đuôi mình");
            }
            if (comboBox1.Text == "Mê Cung")
            {
                if (vacham.xetvachamtuong(daunhungconran) == true)
                {
                    die(@"E:\data\038.wav");
                    //var myPlayer = new System.Media.SoundPlayer();
                    //myPlayer.SoundLocation = @"E:\data\m_end.wav";
                    //myPlayer.Play();
                    MessageBox.Show("Bạn đã die do chạm tường");
                }
            }
            else if (comboBox1.Text == "Đại Chiến")
            {
                if (vacham.xetvachamtuongchiendau(daunhungconran) == true)
                {
                    die(@"E:\data\038.wav");
                    //var myPlayer = new System.Media.SoundPlayer();
                    //myPlayer.SoundLocation = @"E:\data\m_end.wav";
                    //myPlayer.Play();
                    MessageBox.Show("Bạn đã die do chạm tường");
                }
            }
            // Kết thúc xét va chạm.
        }
        void batdaugame()
        {
            R = true;
            L = false;
            D = false;
            U = false;
            diem = 0;
            if (radioButton3.Checked == true)
            {
                Dieukhiendau3conran.Interval = 70;
                Rantieudietnhau.Interval = 70;
                Anmoi.Interval = 70;
                Thancuaconran.Interval = 70;
                Dichuyendauconran.Interval = 70;
                Dieukhienrankidihukhong.Interval = 70;
                Panel_Paint.Interval = 70;
                Dongho.Interval = 1200;
            }
            else if (radioButton2.Checked == true)
            {
                Dieukhiendau3conran.Interval = 100;
                Rantieudietnhau.Interval = 100;
                Anmoi.Interval = 100;
                Thancuaconran.Interval = 100;
                Dichuyendauconran.Interval = 100;
                Dieukhienrankidihukhong.Interval = 100;
                Panel_Paint.Interval = 100;
                Dongho.Interval = 1000;
            }
            else if (radioButton1.Checked == true)
            {
                Dieukhiendau3conran.Interval = 170;
                Rantieudietnhau.Interval = 170;
                Anmoi.Interval = 170;
                Thancuaconran.Interval = 170;
                Dichuyendauconran.Interval = 170;
                Dieukhienrankidihukhong.Interval = 170;
                Panel_Paint.Interval = 170;
                Dongho.Interval = 800;
            }
            else
            {
                MessageBox.Show("Chọn mức độ chơi");
                radioButton1.Checked = true;
            }
            if (comboBox1.Text == "Tự Do")
            {
                load();
                Dichuyendauconran.Start();
                Anmoi.Start();
                Thancuaconran.Start();
                thucan = new ThucAn();
                thucan.TaoThucAn2(panel1, listthucan);
                Panel_Paint.Start();
            }
            else if (comboBox1.Text == "Mê Cung")
            {
                load();
                vatcan = new VatCan();
                vatcan.taovatcan(panel1,tuong);
                Dichuyendauconran.Start();
                Anmoi.Start();
                Thancuaconran.Start();
                thucan = new ThucAn();
                thucan.TaoThucAn(panel1, listthucan);
                Panel_Paint.Start();
            }
            else if (comboBox1.Text == "Đại Chiến")
            {
                load();
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 470, 20, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 470, 470, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 20, 470, daucuaconran, panel1, daunhungconran);
                daunhungconran[3].BackgroundImage = Properties.Resources.jkljlkj___Copy__2_;

                Dichuyendauconran.Start();
                Anmoi.Start();
                Thancuaconran.Start();
                Dieukhiendau3conran.Start();
                Rantieudietnhau.Start();
                vatcan = new VatCan();
                vatcan.taovatcan1(panel1, tuong);
                thucan = new ThucAn();
                thucan.TaoThucAn1(panel1, listthucan);
                Panel_Paint.Start();
            }
            else if (comboBox1.Text == "Kỳ Dị Hư Không")
            {
                load();
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 470, 470, daucuaconran, panel1, daunhungconran);
                PictureBox than = new PictureBox();
                taopicturebox(10, 10, daunhungconran[1].Left + 10, daunhungconran[1].Top, than, panel1, thancuaconran1);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 120, 100, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 380, 400, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 120, 400, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 380, 100, daucuaconran, panel1, daunhungconran);
                daucuaconran = new PictureBox();
                taopicturebox(10, 10, 250, 250, daucuaconran, panel1, daunhungconran);
                daunhungconran[2].BackgroundImage = Properties.Resources.jkljlkj___Copy;
                daunhungconran[3].BackgroundImage = Properties.Resources.jkljlkj___Copy__2_;
                daunhungconran[4].BackgroundImage = Properties.Resources.jkljlkj___Copy__3_;
                daunhungconran[5].BackgroundImage = Properties.Resources.jkljlkj___Copy__4_;
                daunhungconran[6].BackgroundImage = Properties.Resources._42141411;
                thucan = new ThucAn();
                thucan.TaoThucAn1(panel1, listthucan);
                Dichuyendauconran.Start();
                Dieukhienrankidihukhong.Start();
                Anmoi.Start();
                Thancuaconran.Start();
                Khonggianhukhong.Start();
                Panel_Paint.Start();
            }
            else
            {
                MessageBox.Show("Bạn Hãy Chọn Loại Trò Chơi!!");

            }
        }
        void giaiphong()
        {
            giaiphongdulieu = new Giaiphongdulieu();
            giaiphongdulieu.giaiphong(thancuaconran, panel1);
            giaiphongdulieu.giaiphong(thancuaconran1, panel1);
            giaiphongdulieu.giaiphong(daunhungconran, panel1);
            giaiphongdulieu.giaiphong(listthucan, panel1);
            giaiphongdulieu.giaiphong(tuong, panel1);
        }

        void die(string a)
        {
            Dichuyendauconran.Stop();
            Anmoi.Stop();
            Thancuaconran.Stop();
            if (comboBox1.Text == "Đại Chiến")
            {
                Dieukhiendau3conran.Stop();
                Rantieudietnhau.Stop();
            }
            else if (comboBox1.Text == "Kỳ Dị Hư Không")
            {
                Dieukhienrankidihukhong.Stop();
                Khonggianhukhong.Stop();
            }
            Panel_Paint.Stop();
            if (diem > diemcao)
                diemcao = diem;
            label5.Text = diemcao.ToString();
            startBtn.Enabled = true;
            button2.Enabled = false;
            Dongho.Stop();
            //var myPlayer = new System.Media.SoundPlayer();
            //myPlayer.SoundLocation = a;
            //myPlayer.Play();
            MessageBox.Show( "Điểm của bạn là : " + diem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Dừng Lại (P)")
            {
                button2.Text = "Tiếp Tục";

                Dichuyendauconran.Stop();
                Anmoi.Stop();
                Thancuaconran.Stop();
                Dongho.Stop();
                 if (comboBox1.Text == "Đại Chiến")
                {
                    Dieukhiendau3conran.Stop();
                    Rantieudietnhau.Stop();
                }
                else if (comboBox1.Text == "Kỳ Dị Hư Không")
                {
                    Dieukhienrankidihukhong.Stop();
                    Khonggianhukhong.Stop();
                }
            }
            else
            {
                Dongho.Start();
                button2.Text = "Dừng Lại (P)";
                Dichuyendauconran.Start();
                Anmoi.Start();
                Thancuaconran.Start();
                if (comboBox1.Text == "Đại Chiến")
                {
                    Dieukhiendau3conran.Start();
                    Rantieudietnhau.Start();
                }
                else if (comboBox1.Text == "Kỳ Dị Hư Không")
                {
                    Dieukhienrankidihukhong.Start();
                    Khonggianhukhong.Start();
                }
            }
        }
        private void Dongho_Tick(object sender, EventArgs e)
        {
            giay -= 1;
            if (phut == 0 && giay == 0)
            {
                die(@"E:\data\080.wav");
            }
            if (giay == 0)
            {
                phut -= 1;
                giay = 59;
            }
            if (giay > 59)
            {
                phut += 1;
                giay -= 60;
            }
            label7.Text = giay.ToString();
            label6.Text = phut.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
