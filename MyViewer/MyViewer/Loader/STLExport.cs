using MyViewer.Mesh;
using System.Collections.Generic;

namespace MyViewer.Loader
{
    class CSTLExport
    {
        public static float[] Get_Mesh_Vertices(CTriangleMesh[] meshArray)
        {
            List<float> vertices = new List<float>();

            for (int i = 0; i < meshArray.Length; i++)
            {
                /* vertex 1 */
                vertices.Add(meshArray[i].vert1.X);
                vertices.Add(meshArray[i].vert1.Y);
                vertices.Add(meshArray[i].vert1.Z);
                /* vertex 2 */
                vertices.Add(meshArray[i].vert2.X);
                vertices.Add(meshArray[i].vert2.Y);
                vertices.Add(meshArray[i].vert2.Z);
                /* vertex 3 */
                vertices.Add(meshArray[i].vert3.X);
                vertices.Add(meshArray[i].vert3.Y);
                vertices.Add(meshArray[i].vert3.Z);
            }

            return vertices.ToArray();
        }


        /**
        * @brief  This function creates a normal array for OpenGL vertex array object from given triangular mesh array
        * @param  meshArray
        * @retval normals
        */
        public static float[] Get_Mesh_Normals(CTriangleMesh[] meshArray)
        {
            List<float> normals = new List<float>();

            for (int i = 0; i < meshArray.Length; i++)
            {
                /* normal 1 */
                normals.Add(meshArray[i].normal1.X);
                normals.Add(meshArray[i].normal1.Y);
                normals.Add(meshArray[i].normal1.Z);
                /* normal 2 */
                normals.Add(meshArray[i].normal2.X);
                normals.Add(meshArray[i].normal2.Y);
                normals.Add(meshArray[i].normal2.Z);
                /* normal 3 */
                normals.Add(meshArray[i].normal3.X);
                normals.Add(meshArray[i].normal3.Y);
                normals.Add(meshArray[i].normal3.Z);
            }

            return normals.ToArray();
        }
    }
}
