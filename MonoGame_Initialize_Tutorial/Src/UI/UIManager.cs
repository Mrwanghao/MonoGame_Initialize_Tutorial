using System.Collections.Generic;
using Nez;

namespace UI
{
    public class UIManager
    {
        private static UIManager _instance;
        public static UIManager Instance
        { 
            set { _instance = value; }
            get 
            { 
                if(_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        public void Update()
        { 
            foreach(var uibase in _UIBases.Values)
            {
                uibase.Update();
            }
        }

        public void Open(string windowName, UIBase uiBase)
        { 
            if(_UIBases.ContainsKey(windowName))
            {
                var window = _UIBases[windowName];
                window.Show();

                Debug.log(string.Format("there is {0} window.", windowName));

                uiBase.Destroy();
            }
            else 
            {
                _UIBases.Add(windowName, uiBase);
                uiBase.Show();
            }
        }

        public void Close(string windowName)
        { 
            if(_UIBases.ContainsKey(windowName))
            {
                var window = _UIBases[windowName];
                window.Hide();
            }
            else
            {
                Debug.log(string.Format("can't find {0} window.", windowName));
            }
        }

        private Dictionary<string, UIBase> _UIBases = new Dictionary<string, UIBase>();
    }
}
