using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;




namespace UI
{
    public abstract class UIBase : Component, UILifeCycleInterface
    {

        private int uiID;
        public int UIID
        { 
            get { return uiID; }
        }

        private string uiName;
        public string UIName
        {
            get 
            { 
                if(uiName == null)
                {
                    uiName = entity.name;
                }
                return uiName;
            }
            set 
            { 
                uiName = value; 
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize(string eventKey, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        { }

        public void Show()
        { }

        internal void Destroy()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        { }
    }
}
