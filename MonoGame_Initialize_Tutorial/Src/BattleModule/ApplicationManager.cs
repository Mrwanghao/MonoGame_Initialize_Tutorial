using System;
using Nez;
namespace BattleModule
{
    public class ApplicationManager : Component, IUpdatable
    {
        private static ApplicationManager _instance;
        public static ApplicationManager Instance
        {
            get 
            { 
                if(_instance == null)
                {
                    var _instanceEntity = Core.scene.findEntity("ApplicationManager");
                    if(_instanceEntity == null)
                    {
                        _instanceEntity = CreateApplicationManager();
                    }

                    _instance = _instanceEntity.getComponent<ApplicationManager>();
                }
                return _instance;
            }
        }

        private static Entity CreateApplicationManager()
        {
            Entity applicationManager = Core.scene.createEntity("ApplicationManager");
            applicationManager.addComponent<ApplicationManager>();
            return applicationManager;
        }

        public static ApplicationVoidCallBack s_ApplicationOnUpdate = null;

        public override void initialize()
        {
            base.initialize();

            LaunchApplication();

        }

        //注册代理机制从这里开始
        private void LaunchApplication()
        { 

        }

        public void update()
        {
            if(s_ApplicationOnUpdate != null)
            {
                s_ApplicationOnUpdate();
            }
        }
    }

    public delegate void ApplicationBoolCallBack(bool status);
    public delegate void ApplicationVoidCallBack(); 
}
