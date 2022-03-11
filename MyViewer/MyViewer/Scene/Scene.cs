using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyViewer.Model;
using MyViewer.Renderer;
using System.Drawing;

namespace MyViewer.Scene
{
    enum E_BUTTON_STATE
    {
        LEFT,
        RIGHT,
        MIDDLE
    }

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

        public void OnMouseDown(Point point, E_BUTTON_STATE state)
        {
            _pointStart = point;
        }
        public void OnMouseMove(Point point, E_BUTTON_STATE state)
        {
            switch (state)
            {
                case E_BUTTON_STATE.LEFT:
                    break;
                case E_BUTTON_STATE.RIGHT:
                    break;
                default:
                    break;
            }
        }
        public void OnMouseUp(Point point, E_BUTTON_STATE state)
        {

        }
    }
}
