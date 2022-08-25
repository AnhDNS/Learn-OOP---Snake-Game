using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class ThucAn : MaTran
    {
        Random rd = new Random();
        int l;
        int k;
        public void TaoThucAn(Panel b, List<PictureBox> c)
        {
            matran();
            do
            {
                l = rd.Next(0, 49);
                k = rd.Next(0, 49);
            } while (arr[k, l] == 1);
            PictureBox a = new PictureBox();
            a.Width = 10;
            a.Height = 10;
            a.Left = l * 10;
            a.Top = k * 10;
            a.BackgroundImage = Properties.Resources.jkljlkj;
            a.BackgroundImageLayout = ImageLayout.Stretch;
            b.Controls.Add(a);
            c.Add(a);
        }
        public void TaoThucAn1(Panel b, List<PictureBox> c)
        {
            matran1();
            do
            {
                l = rd.Next(0, 49);
                k = rd.Next(0, 49);
            } while (arr[k, l] == 1);
            PictureBox a = new PictureBox();
            a.Width = 10;
            a.Height = 10;
            a.Left = l * 10;
            a.Top = k * 10;
            a.BackgroundImage = Properties.Resources.jkljlkj;
            a.BackgroundImageLayout = ImageLayout.Stretch;
            b.Controls.Add(a);
            c.Add(a);
        }
        public void TaoThucAn2(Panel b, List<PictureBox> c)
        {
            l = rd.Next(0, 49);
            k = rd.Next(0, 49);
            PictureBox a = new PictureBox();
            a.Width = 10;
            a.Height = 10;
            a.Left = l * 10;
            a.Top = k * 10;
            a.BackgroundImage = Properties.Resources.jkljlkj;
            a.BackgroundImageLayout = ImageLayout.Stretch;
            b.Controls.Add(a);
            c.Add(a);
        }
    }
}
