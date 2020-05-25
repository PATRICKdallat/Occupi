using System;
using PAT.Portable.EventArguments;

namespace PAT.Portable.Services
{
    public interface IConnectivityService : IDisposable
    {
        bool IsConnected { get; }
        
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }

    public delegate void ConnectivityChangedEventHandler(object sender, ConnectivityChangedEventArgs e);
}