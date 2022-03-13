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
            
            STLReader stlReader = new STLReader(strPath);

            CTriangleMesh[] meshArray = stlReader.ReadFile();

            string strName = "";
            CModelItem modelItem = new CModelItem();
            modelItem.Name = strName;
            modelItem.parameterArray = CSTLExport.Get_Mesh_Vertices(meshArray);
            modelItem.normalArray = CSTLExport.Get_Mesh_Normals(meshArray);
            modelItem._minPos = stlReader.GetMinMeshPosition(meshArray);
            modelItem._maxPos = stlReader.GetMaxMeshPosition(meshArray);
           
            if (stlReader.Get_Process_Error() == true)
            {
                ModelDocument.Instance().AddModel(modelItem, strName);
                bRes = true;
            }



            return bRes;
        }
    }
}
