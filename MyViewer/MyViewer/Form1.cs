using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using MyViewer.Scene;

namespace MyViewer
{
    public partial class Form1 : Form
    {
        private CScene _scene = new CScene();

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
            _scene.DrawRender();
            glControl1.SwapBuffers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog newFileDialog = new OpenFileDialog();
            newFileDialog.Filter = "STL Files|*.stl;*.txt;";

            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseDownLocation = new Point(e.X, e.Y);
            _scene.OnMouseDown(mouseDownLocation, e.Button);
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseMoveLocation = new Point(e.X, e.Y);
            _scene.OnMouseMove(mouseMoveLocation, e.Button);
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            Point mouseUpLocation = new Point(e.X, e.Y);
            _scene.OnMouseUp(mouseUpLocation, e.Button);
        }
    }
}
