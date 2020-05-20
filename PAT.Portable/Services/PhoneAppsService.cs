using System.Threading.Tasks;
using PAT.Services;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public class PhoneAppsService : IPhoneAppsService
    {
        public async void LaunchApp(string uri)
        {
            if (await Launcher.CanOpenAsync(uri))
                await Launcher.OpenAsync(uri);
        }

        public void OpenBrowser(string uri) => Browser.OpenAsync(uri);

        public void DialPhoneNumber(string mobile) => PhoneDialer.Open(mobile);

        public async Task OpenMapApp(Location location) => await Map.OpenAsync(location);
        public async Task OpenMapApp(Location location, MapLaunchOptions options = null) => await Map.OpenAsync(location, options);

        public async Task OpenMapApp(Placemark placemark) => await Map.OpenAsync(placemark);
        public async Task OpenMapApp(Placemark placemark, MapLaunchOptions options = null) => await Map.OpenAsync(placemark, options);
        
        public async Task OpenMapApp(double latitude, double longitude) => await Map.OpenAsync(latitude, longitude);
        public async Task OpenMapApp(double latitude, double longitude, MapLaunchOptions options = null) => await Map.OpenAsync(latitude, longitude, options);
        
        public async Task ComposeEmail() => await Email.ComposeAsync();        
        public async Task ComposeEmail(EmailMessage message) => await Email.ComposeAsync(message);
        public async Task ComposeEmail(string subject, string body, params string[] to) => await Email.ComposeAsync(subject,body,to);
        
        public async Task ComposeSms() => await Sms.ComposeAsync();
        public async Task ComposeSms(SmsMessage message) => await Sms.ComposeAsync(message);
        
        public async Task ShareContent(string textContent) => await Share.RequestAsync(textContent);
        public async Task ShareContent(string shareContentTitle, string textContent) => await Share.RequestAsync(textContent, shareContentTitle);
        public async Task ShareContent(ShareTextRequest request) => await Share.RequestAsync(request);
        public async Task ShareContent(ShareFileRequest request) => await Share.RequestAsync(request);
    }
}
