using System.Drawing;
using OpenTK.Graphics.OpenGL;


namespace MyViewer.Model
{
    class CModelItem
    {
        public Color color { get; set; }
        public float[] parameterArray { get; set; }
        public float[] normalArray { get; set; }

        public CModelItem()
        {
            color = Color.White;
        }

        public void Draw()
        {
            GL.PushMatrix();
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, parameterArray);
            GL.Color3(color.R / 255.0, color.G / 255.0, color.B / 255.0);
            GL.NormalPointer(NormalPointerType.Float, 0, normalArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, parameterArray.Length / 3);
            GL.DisableClientState(ArrayCap.NormalArray);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.PopMatrix();
        }
    }
}
