using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyViewer.Doc;
using MyViewer.Loader;
using MyViewer.Mesh;
using MyViewer.Model;
using System.Windows.Forms;


namespace MyViewer.Command
{
    class CCommandReadFile : ICommand
    {
        public string FilePath { get; set; }


        public void Execute()
        {
            _openDialog();
        }

        private void _openDialog()
        {
            OpenFileDialog newFileDialog = new OpenFileDialog();
            newFileDialog.Filter = "STL Files|*.stl;*.txt;";

            if (newFileDialog.ShowDialog() == DialogResult.OK)
            {
                _readFile(newFileDialog.FileName);
            }
        }
        private bool _readFile(string strPath)
        {
            bool bRes = false;

            

            //STLReader stlReader = new STLReader(strPath);

            //CTriangleMesh[] meshArray = stlReader.ReadFile();

            //modelVAO = new Batu_GL.VAO_TRIANGLES();
            //modelVAO.parameterArray = STLExport.Get_Mesh_Vertices(meshArray);
            //modelVAO.normalArray = STLExport.Get_Mesh_Normals(meshArray);
            //modelVAO.color = Color.Crimson;
            //minPos = stlReader.GetMinMeshPosition(meshArray);
            //maxPos = stlReader.GetMaxMeshPosition(meshArray);
            //orb.Reset_Orientation();
            //orb.Reset_Pan();
            //orb.Reset_Scale();
            //if (stlReader.Get_Process_Error())
            //{
            //    modelVAO = null;
            //    /* if there is an error, deinitialize the gl monitor to clear the screen */
            //    Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
            //    GL_Monitor.SwapBuffers();
            //}
            string strName = "";
            CModelItem modelItem = new CModelItem();
            modelItem.Name = strName;

            ModelDocument.Instance().AddModel(modelItem, strName);

            return bRes;
        }
    }
}
