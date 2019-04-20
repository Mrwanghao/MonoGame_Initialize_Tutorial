using System;
using System.Collections.Generic;
using UI;

namespace BattleModule
{
    public abstract class IApplicationStatus
    {
        private List<UIBase> s_uibases = new List<UIBase>();



        public void OpenUIWindow(string windowName)
        {
            //UIManager.Instance.Open();
        }

        public void HideUIWindow<T>() where T : UIBase
        {
            string windowName = typeof(T).Name;

        }

    }
}
