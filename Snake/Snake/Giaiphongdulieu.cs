using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Giaiphongdulieu
    {
        public void giaiphong(List<PictureBox> a,Panel b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                b.Controls.Remove(a[i]);
                a.RemoveAt(i);
                i--;
            }
        }
    }
}
