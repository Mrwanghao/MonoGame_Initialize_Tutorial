using InputSystem.Interface;

namespace InputSystem
{
    public class InputDispatcher<Event> : IInputDispatcher where Event : IInputEventBase
    {
        public InputDispatcher()
        {
            
        }
    }
}
