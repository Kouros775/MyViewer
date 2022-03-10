using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyViewer.Loader;


namespace MyViewer.Command
{
    class CommandReadFile : ICommand
    {
        private string _strFilePath;
        private bool _bUpdateActuator = false;
         
        public void Execute()
        {
            _bUpdateActuator = _readFile(_strFilePath);
        }

        private bool _readFile(string strPath)
        {
            bool bRes = false;


            STLReader stlReader = new STLReader(strPath);

            TriangleMesh[] meshArray = stlReader.ReadFile();

            modelVAO = new Batu_GL.VAO_TRIANGLES();
            modelVAO.parameterArray = STLExport.Get_Mesh_Vertices(meshArray);
            modelVAO.normalArray = STLExport.Get_Mesh_Normals(meshArray);
            modelVAO.color = Color.Crimson;
            minPos = stlReader.GetMinMeshPosition(meshArray);
            maxPos = stlReader.GetMaxMeshPosition(meshArray);
            orb.Reset_Orientation();
            orb.Reset_Pan();
            orb.Reset_Scale();
            if (stlReader.Get_Process_Error())
            {
                modelVAO = null;
                /* if there is an error, deinitialize the gl monitor to clear the screen */
                Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
                GL_Monitor.SwapBuffers();
            }



            return bRes;
        }
    }
}
