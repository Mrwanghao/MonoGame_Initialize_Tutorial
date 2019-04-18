using System;
namespace InputSystem.Interface
{
    public abstract class IInputProxyBase
    {
        private static bool active = true;
        public static bool Active
        { 
            set { active = value; }
            get { return active; }
        }
    }
}
