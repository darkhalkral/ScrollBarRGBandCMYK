using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ders4
{
    public partial class Form1 : Form
    {

        double R, G, B, C, M, Y, K, Rc, Gc, Bc = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void rgb()
        {
            R = vScrollBar1.Value;
            G = vScrollBar2.Value;
            B = vScrollBar3.Value;
            if (R == 0 && G == 0 && B == 0)
            {
                C = 0;
                M = 0;
                Y = 0;
                K = 0;
            }
            else
            {
                vScrollBar1.Value = Convert.ToInt32(Math.Round(R));
                vScrollBar2.Value = Convert.ToInt32(Math.Round(G));
                vScrollBar3.Value = Convert.ToInt32(Math.Round(B));
                Rc = R / 255;
                Gc = G / 255;
                Bc = B / 255;
                K = 1 - Math.Max(Math.Max(Rc, Gc), Bc);
                C = (1 - Rc - K) / (1 - K) * 100;
                M = (1 - Gc - K) / (1 - K) * 100;
                Y = (1 - Bc - K) / (1 - K) * 100;
                hScrollBar1.Value = Convert.ToInt32(C);
                hScrollBar2.Value = Convert.ToInt32(M);
                hScrollBar3.Value = Convert.ToInt32(Y);
                hScrollBar4.Value = Convert.ToInt32(K);
            }
        }
        private void cmyk()
        {
            C = hScrollBar1.Value;
            M = hScrollBar2.Value;
            Y = hScrollBar3.Value;
            K = hScrollBar4.Value;
            R = 255 * (1 - (C / 100)) * (1 - (K / 100));
            G = 255 * (1 - (M / 100)) * (1 - (K / 100));
            B = 255 * (1 - (Y / 100)) * (1 - (K / 100));
            vScrollBar1.Value = Convert.ToInt32(Math.Round(R));
            vScrollBar2.Value = Convert.ToInt32(Math.Round(G));
            vScrollBar3.Value = Convert.ToInt32(Math.Round(B));

        }
        private void Form1_Load(object sender, EventArgs e)
        {
          vScrollBar1.Minimum = 0;
          vScrollBar1.Maximum = 255;
          vScrollBar1.LargeChange = 1;
          vScrollBar2.Minimum = 0;
          vScrollBar2.Maximum = 255;
          vScrollBar2.LargeChange = 1;
          vScrollBar3.Minimum = 0;
          vScrollBar3.Maximum = 255;
          vScrollBar3.LargeChange = 1;
          hScrollBar1.Minimum = 0;
          hScrollBar1.Maximum = 100;
          hScrollBar1.LargeChange = 1;
          hScrollBar2.Minimum = 0;
          hScrollBar2.Maximum = 100;
          hScrollBar2.LargeChange = 1;
          hScrollBar3.Minimum = 0;
          hScrollBar3.Maximum = 100;
          hScrollBar3.LargeChange = 1;
          hScrollBar4.Minimum = 0;
          hScrollBar4.Maximum = 100;
          hScrollBar4.LargeChange = 1;
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {        
            rgb();           
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(vScrollBar1.Value, vScrollBar2.Value, vScrollBar3.Value);
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {          
            rgb();           
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(vScrollBar1.Value, vScrollBar2.Value, vScrollBar3.Value);
        }
        private void vScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {          
            rgb();
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(vScrollBar1.Value, vScrollBar2.Value, vScrollBar3.Value);
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cmyk();
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            cmyk();
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            cmyk();
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            cmyk();
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
        }
    }
}
