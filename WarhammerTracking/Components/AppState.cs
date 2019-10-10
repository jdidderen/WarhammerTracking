using System;

namespace WarhammerTracking.Components
{
    public class AppState
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }    
    }
}