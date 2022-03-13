using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyViewer.Doc;
using MyViewer.Model;

namespace MyViewer.Doc
{
    class ModelDocument : CDocument
    {
        private Dictionary<string, CModelItem> _modelItems = new Dictionary<string, CModelItem>();

        private static ModelDocument _instance;
        public static ModelDocument Instance()
        {
            if (_instance == null)
            {
                _instance = new ModelDocument();
            }
            return _instance;
        }

        public bool AddModel(CModelItem model, string strName)
        {
            bool bRes = false;

            if (model == null)
            {
                bRes = false;
            }
            else
            {
                if (_modelItems.ContainsKey(strName))
                {
                    bRes = false;
                }
                else
                {
                    model.Name = strName;
                    _modelItems.Add(strName, model);
                }
            }

            return bRes;
        }

        public bool RemoveModel(string strName)
        {
            bool bRes = false;

            if (_modelItems.ContainsKey(strName))
            {
                _modelItems.Remove(strName);
               bRes = true;
            }
            else
            {
                bRes = false;
            }

            return bRes;
        }

        public CModelItem GetModelItem(string strName)
        {
            CModelItem modelItem;

            if (_modelItems.TryGetValue(strName, out modelItem))
                return modelItem;
            else
                return null;
        }
    }
}
