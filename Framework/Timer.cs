using System;

namespace Hx001.Framework
{
    public class Timer
    {
        public EventHandler Done;
        
        protected virtual void OnDone(EventArgs e)
        {
            EventHandler handler = Done;
            handler?.Invoke(this, e);
        }
    }
}