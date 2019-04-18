using System;
namespace UI
{
    public interface UILifeCycleInterface
    {
        void Initialize(string eventKey, int id);
        void Dispose();
    }
}
