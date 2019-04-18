using System;
using System.Collections.Generic;
using InputSystem.Interface;
using Nez;

namespace InputSystem.Proxy
{
    public class InputOperationEventProxy : IInputProxyBase
    {
        private static List<IInputOperationEventCreator> creators = new List<IInputOperationEventCreator>();

        public static void Initialize()
        { 
            
        }




        public static void Update()
        { 
            if(Active)
            { 
                for(int index = 0, size = creators.Count; index < size; index++)
                {
                    try 
                    {
                        creators[index].TriggerEvent();
                    }
                    catch(Exception e)
                    {
                        Debug.log(e.ToString());
                    }
                }
            }
        }
    }
}
