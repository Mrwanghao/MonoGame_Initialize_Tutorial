using InputSystem.Interface;
using Microsoft.Xna.Framework.Input;
using Nez;
namespace InputSystem
{
    public class CustomEvent : IInputOperationEventBase, IInputOperationEventCreator
    {
        public void TriggerEvent()
        { 
            if(Input.isKeyPressed(Keys.Space))
            {
                //dispatch event to every listener
                Debug.log("Dispatch event to every listener.");


            }
        }
    }
}
