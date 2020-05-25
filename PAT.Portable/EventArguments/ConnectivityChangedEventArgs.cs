using System;

namespace PAT.Portable.EventArguments
{
    public class ConnectivityChangedEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
    }
}