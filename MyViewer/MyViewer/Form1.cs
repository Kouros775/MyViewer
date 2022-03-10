using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;


namespace MyViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void glControl1_Load(object sender, EventArgs e)
        {

        }

        private void GL_Screen_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }


        private void GL_Screen_Paint(object sender, PaintEventArgs e)
        {
            glControl1.SwapBuffers();
        }
    }
}
