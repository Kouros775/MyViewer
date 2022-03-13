using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyViewer.Model;
using MyViewer.Renderer;
using System.Drawing;
using System.Windows.Forms;

namespace MyViewer.Scene
{
    class CScene
    {
        private CRenderer _renderer = new CRenderer();
        private Point _pointStart = new Point(0, 0);
        public CScene()
        {

        }
        ~CScene()
        {

        }

        public void DrawRender()
        {
            _renderer.DrawModel();
        }

        public void OnMouseDown(Point point, MouseButtons buttonState)
        {
            _pointStart = point;
        }
        public void OnMouseMove(Point point, MouseButtons buttonState)
        {
        }
        public void OnMouseUp(Point point, MouseButtons buttonState)
        {

        }
        public void TEMP_AddModel()
        {

        }
    }
}
