using System;
namespace InputSystem.Interface
{
    public abstract class IInputEventBase
    {
        public float createTime;
        protected string eventKey;

        public string EventKey
        {
            get 
            {  
                if(eventKey == null)
                {
                    eventKey = GetEventKey();
                }
                return eventKey;
            }
            set 
            { 
                eventKey = value; 
            }
        }

        public IInputEventBase()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            eventKey = null;
            createTime = Nez.Time.timeSinceSceneLoad;
        }

        public virtual string GetEventKey()
        { 
            if(eventKey == null)
            {
                eventKey = this.ToString();
            }
            return eventKey;
        }
    }
}
