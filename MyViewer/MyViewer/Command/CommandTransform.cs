using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace MyViewer.Command
{
    class CCommandTransform : ICommand
    {
        protected Matrix4 _matrix = new Matrix4();
        public Matrix4 Matrix
        {
            get { return _matrix; }
        }

        public virtual void Execute()
        {

        }

    }
}
