using System;
using System.Collections.Generic;

namespace BattleModule
{
    public class GlobalLogicManager
    {
        public void Initialize()
        {
            ApplicationManager.s_ApplicationOnUpdate += Update;
        }

        private List<IApplicationGlobalLogic> s_globalLogics = new List<IApplicationGlobalLogic>();

        private void Update()
        {
            for(int i = 0, size = s_globalLogics.Count; i < size; i++)
            {
                try
                {
                    s_globalLogics[i].Update();
                }
                catch(Exception e)
                {
                    Nez.Debug.log(e.ToString());
                }
            }
        }
    }
}
