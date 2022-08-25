using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class TaoBoss
    {
        public void Dieukhiendau3conran(List<PictureBox> daunhungconran, List<PictureBox> listthucan)
        {
            if (daunhungconran[1].Left < listthucan[0].Left)
            {
                daunhungconran[1].Left += 10;
            }
            else if (daunhungconran[1].Left > listthucan[0].Left)
            {
                daunhungconran[1].Left -= 10;
            }
            else if (daunhungconran[1].Top < listthucan[0].Top)
            {
                daunhungconran[1].Top += 10;
            }
            else if (daunhungconran[1].Top > listthucan[0].Top)
            {
                daunhungconran[1].Top -= 10;
            }

            // Đầu con rắn thứ 2
            if (daunhungconran[2].Left < listthucan[0].Left)
            {
                daunhungconran[2].Left += 10;
            }
            else if (daunhungconran[2].Left > listthucan[0].Left)
            {
                daunhungconran[2].Left -= 10;
            }
            else if (daunhungconran[2].Top < listthucan[0].Top)
            {
                daunhungconran[2].Top += 10;
            }
            else if (daunhungconran[2].Top > listthucan[0].Top)
            {
                daunhungconran[2].Top -= 10;
            }
            // Đầu con rắn thứ 3

            if (daunhungconran[3].Left < daunhungconran[0].Left)
            {
                daunhungconran[3].Left += 10;
            }
            else if (daunhungconran[3].Left > daunhungconran[0].Left)
            {
                daunhungconran[3].Left -= 10;
            }
            else if (daunhungconran[3].Top < daunhungconran[0].Top)
            {
                daunhungconran[3].Top += 10;
            }
            else if (daunhungconran[3].Top > daunhungconran[0].Top)
            {
                daunhungconran[3].Top -= 10;
            }

        }
        public bool Rantieudietnhau(List<PictureBox> daunhungconran, List<PictureBox> thancuaconran)
        {
            bool t = false;
            for (int i = 0; i < thancuaconran.Count; i++)
            {
                if (daunhungconran[1].Location == thancuaconran[i].Location)
                {
                    daunhungconran[1].Left = 470;
                    daunhungconran[1].Top = 20;
                }
                if (daunhungconran[2].Location == thancuaconran[i].Location)
                {
                    daunhungconran[2].Left = 470;
                    daunhungconran[2].Top = 470;
                }
                if (daunhungconran[3].Location == thancuaconran[i].Location)
                {
                    daunhungconran[3].Left = 20;
                    daunhungconran[3].Top = 470;
                }

            }
            if (daunhungconran[0].Location == daunhungconran[3].Location)
            {
                t = true;
            }
            return t;

        }
        public bool bosskidihukhong(PictureBox daunhungconran, List<PictureBox> listthucan, List<PictureBox> thancuaconran)
        {
            bool t = false;
            if (daunhungconran.Left < listthucan[0].Left)
            {
                daunhungconran.Left += 10;
            }
            else if (daunhungconran.Left > listthucan[0].Left)
            {
                daunhungconran.Left -= 10;
            }
            else if (daunhungconran.Top < listthucan[0].Top)
            {
                daunhungconran.Top += 10;
            }
            else if (daunhungconran.Top > listthucan[0].Top)
            {
                daunhungconran.Top -= 10;
            }
            for (int i = 0; i < thancuaconran.Count; i++)
            {
                if (daunhungconran.Location == thancuaconran[i].Location)
                {
                    daunhungconran.Left = 470;
                    daunhungconran.Top = 470;
                    t = true;
                }
            }
            return t;
        }

    }
}
