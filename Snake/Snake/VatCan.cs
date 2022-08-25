using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class VatCan : MaTran
    {
        public void taovatcan(Panel b,List<PictureBox> c)
        {
            matran();
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                {
                    if (arr[i,j] == 1)
                    {
                        PictureBox a = new PictureBox();
                        a.Width = arr[i, j] * 10;
                        a.Height = arr[i, j] * 10;
                        a.Left = j * 10;
                        a.Top = i * 10;
                        a.BackgroundImage = Properties.Resources.jkljlkj;
                        a.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Controls.Add(a);
                        c.Add(a);
                    }
                }
        }
        public void taovatcan1(Panel b,List<PictureBox> c)
        {
            matran1();
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        PictureBox a = new PictureBox();
                        a.Width = arr[i, j] * 10;
                        a.Height = arr[i, j] * 10;
                        a.Left = j * 10;
                        a.Top = i * 10;
                        a.BackgroundImage = Properties.Resources.jkljlkj;
                        a.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Controls.Add(a);
                        c.Add(a);
                    }
                }
        }
    }
}
