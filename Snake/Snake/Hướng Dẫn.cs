using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Hướng_Dẫn : Form
    {
        public Hướng_Dẫn()
        {
            InitializeComponent();
        }

        private void Hướng_Dẫn_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
