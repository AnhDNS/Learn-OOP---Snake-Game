using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class XetVaCham : MaTran
    {
        public bool kiemtravacham(List<PictureBox> daunhungconran,List<PictureBox> thannhungconran)
        {
            bool t = false;
            for(int i=0;i<thannhungconran.Count;i++)
            {
                if (daunhungconran[0].Location == thannhungconran[i].Location)
                {
                    t = true;                   
                }
            }
            return t;
        }
        public bool xetvachamtuong(List<PictureBox> daunhungconran)
        {
            bool t = false;
            matran();
            if (arr[daunhungconran[0].Location.Y / 10, daunhungconran[0].Location.X / 10] == 1)
            {

                t = true;
            }
            return t;
        }
        public bool xetvachamtuongchiendau(List<PictureBox> daunhungconran)
        {
            bool t = false;
            matran1();
            if (arr[daunhungconran[0].Location.Y / 10, daunhungconran[0].Location.X / 10] == 1)
            {

                t = true;
            }
            return t;
        }
    }
}
