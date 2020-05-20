using System;

namespace PAT.Services
{
    public interface IConnectivityService : IDisposable
    {
        bool IsConnected { get; }
        
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }

    public delegate void ConnectivityChangedEventHandler(object sender, ConnectivityChangedEventArgs e);
}