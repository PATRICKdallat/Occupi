using System;

namespace PAT.Services
{
    public class ConnectivityChangedEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
    }
}