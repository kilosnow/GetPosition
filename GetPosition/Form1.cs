using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetPosition
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        Point mp;

        public Form1()
        {
            InitializeComponent();
        }


        private void timerRun_Tick(object sender, EventArgs e)
        {
            mp = Control.MousePosition;
            labelX.Text = string.Format("坐标 X: {0}", mp.X.ToString());
            labelY.Text = string.Format("坐标 Y: {0}", mp.Y.ToString());
            Color c = getColor();
            labelColor.Text = "颜色: " + c.R.ToString() + c.G.ToString() + c.B.ToString();
            pictureColor.BackColor = c;

        }

        public Color getColor()
        {
            //int h = WindowFromPoint(x, y);
            IntPtr hdc = GetDC(IntPtr.Zero);

            int c =(int)GetPixel(hdc, mp.X, mp.Y);
            return Color.FromArgb(c);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
