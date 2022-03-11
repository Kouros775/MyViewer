using System.Collections.Generic;
using MyViewer.Model;


namespace MyViewer.Renderer
{
    class CRenderer
    {
        private Dictionary<int, CModelItem> _modelItems = new Dictionary<int, CModelItem>();
        public CRenderer()
        {

        }
        ~CRenderer()
        {

        }

        public bool AddModel(CModelItem modelItem, int index)
        {
            bool bRes = false;

            if (IsContainIndex(index))
            {
                bRes = false;
            }
            else
            {
                _modelItems.Add(index, modelItem);
                bRes = true;
            }

            return bRes;
        }
        public bool RemoveModel(int index)
        {
            bool bRes = false;

            if (IsContainIndex(index))
            {
                _modelItems.Remove(index);
                bRes = true;
            }
            else
            {
                bRes = false;
            }

            return bRes;
        }
        public bool IsContainIndex(int index)
        {
            bool bRes = false;

            if (_modelItems.ContainsKey(index))
            {
                bRes = true;
            }
            else
            {
                bRes = false;
            }


            return bRes;
        }

        public void DrawModel()
        {
            foreach (var item in _modelItems)
            {
                item.Value.Draw();
            }
        }
    }
}
