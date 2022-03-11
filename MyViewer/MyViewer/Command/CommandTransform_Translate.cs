using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyViewer.Command;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace MyViewer.Command
{
    class CCommandTransform_Translate : CCommandTransform
    {
        public override void Execute()
        {
            base.Execute();

            _translate();
        }

        private void _translate()
        {

        }
    }
}
