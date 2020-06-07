using Xamarin.Essentials;
using PAT.Portable.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectivityService))]
namespace PAT.Portable.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public event ConnectivityChangedEventHandler ConnectivityChanged;

        public bool IsConnected => ConvertNetworkAccessToIsConnected(Connectivity.NetworkAccess);
        
        private bool ConvertNetworkAccessToIsConnected(NetworkAccess networkAccess)  => networkAccess > NetworkAccess.Local;

        public ConnectivityService()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public void OnConnectivityChanged(PAT.Portable.EventArguments.ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(this, e);
        }

        private void Connectivity_ConnectivityChanged(object sender, Xamarin.Essentials.ConnectivityChangedEventArgs e)
        {
            var connectivityChangedEventArgs = new PAT.Portable.EventArguments.ConnectivityChangedEventArgs();
            connectivityChangedEventArgs.IsConnected = ConvertNetworkAccessToIsConnected(e.NetworkAccess);
            OnConnectivityChanged(connectivityChangedEventArgs);
        }
               
        public void Dispose()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
    }
}
