using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK;

using MyViewer.Scene;
using MyViewer.Command;

using System.Windows.Forms;

namespace MyViewer
{
    public partial class Form1 : Form
    {
        private CScene _scene = new CScene();
        private CButtonList _listButton = new CButtonList();

        public Form1()
        {
            InitializeComponent();
            _listButton.AddCommand(E_COMMAND.READFILE);
        }

        #region LOAD
        private void glControl1_Load(object sender, EventArgs e)
        {

        }

        private void GL_Screen_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }
        #endregion

        #region PAINT
        private void GL_Screen_Paint(object sender, PaintEventArgs e)
        {
            _scene.DrawRender();
            glControl1.SwapBuffers();
        }
        #endregion

        #region MOUSE EVENT
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
        #endregion

        #region BUTTONS
        private void btn_FileLoad(object sender, EventArgs e)
        {
            _listButton.Execute(E_COMMAND.READFILE);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _scene.TEMP_AddModel();
            glControl1.Invalidate();
        }
        #endregion
    }
}
