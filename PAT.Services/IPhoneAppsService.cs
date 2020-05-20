using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PAT.Services
{
    public interface IPhoneAppsService
    {
        void LaunchApp(string uri);
        void OpenBrowser(string uri);
        void DialPhoneNumber(string mobile);

        Task OpenMapApp(Location location);
        Task OpenMapApp(Location location, MapLaunchOptions options = null);

        Task OpenMapApp(Placemark placemark);
        Task OpenMapApp(Placemark placemark, MapLaunchOptions options = null);

        Task OpenMapApp(double latitude, double longitude);
        Task OpenMapApp(double latitude, double longitude, MapLaunchOptions options = null);

        Task ComposeEmail();
        Task ComposeEmail(EmailMessage message);
        Task ComposeEmail(string subject, string body, params string[] to);

        Task ComposeSms();
        Task ComposeSms(SmsMessage message);

        Task ShareContent(string textContent);
        Task ShareContent(string shareContentTitle, string textContent);
        Task ShareContent(ShareTextRequest request);
        Task ShareContent(ShareFileRequest request);
    }
}