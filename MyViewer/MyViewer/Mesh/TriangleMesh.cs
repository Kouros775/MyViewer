using OpenTK;

namespace MyViewer.Mesh
{
    public class CTriangleMesh : CMesh
    {
        public Vector3 normal1;
        public Vector3 normal2;
        public Vector3 normal3;
        public Vector3 vert1;
        public Vector3 vert2;
        public Vector3 vert3;

        public CTriangleMesh()
        {
            normal1 = new Vector3();
            normal2 = new Vector3();
            normal3 = new Vector3();
            vert1 = new Vector3();
            vert2 = new Vector3();
            vert3 = new Vector3();
        }
    }
}
