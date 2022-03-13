using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace MyViewer.Model
{
    class CModelItem
    {
        private string strName;
        public string Name
        {
            get;
            set;
        }

        public Color color { get; set; }
        public float[] parameterArray { get; set; }
        public float[] normalArray { get; set; }
        public Vector3 _minPos { get; set; }
        public Vector3 _maxPos { get; set; }
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


        public static void DrawCube(int size)
        {
            /* draw unit cube then scale it with given size */
            GL.PushMatrix();
            GL.Scale(size, size, size);

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Crimson);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.DarkOrange);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Purple);
            GL.Vertex3(0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, 0.5f, 0.5f);
            GL.Vertex3(-0.5f, 0.5f, -0.5f);
            GL.Vertex3(0.5f, 0.5f, -0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.LightSeaGreen);
            GL.Vertex3(0.5f, -0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, 0.5f);
            GL.Vertex3(-0.5f, -0.5f, -0.5f);
            GL.Vertex3(0.5f, -0.5f, -0.5f);
            GL.End();

            GL.PopMatrix();
        }
    }
}
