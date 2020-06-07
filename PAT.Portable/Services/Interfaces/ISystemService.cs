using System;
using System.Threading;
using Xamarin.Essentials;

namespace PAT.Portable.Services.Interfaces
{
    public interface ISystemService
    {
        void Flashlight(bool on);
        void OpenAppSettings();

        string GetAppName();
        string GetAppPackageName();
        string GetAppBuildVersion();
        string GetAppVersionNumber();
        Version GetAppVersion();

        double GetBatteryLevel();
        bool IsKeepScreenOnEnabled();
        BatteryState GetBatteryState();
        BatteryPowerSource GetPowerSource();
        EnergySaverStatus IsEnergySaverEnabled();

        string GetDeviceName();
        string GetDeviceModel();
        string GetDeviceManufacturer();
        string GetDeviceVersionString();

        AppTheme GetDeviceTheme();
        Version GetDeviceVersion();
        DeviceIdiom GetDeviceType();
        DevicePlatform GetDevicePlatform();
        DisplayInfo GetDeviceDisplayInformation();

        void Speak(string textToSpeech, CancellationToken cancellationToken);
        void Vibrate();
        void Vibrate(double duration);
        void Vibrate(TimeSpan timeSpan);
    }
}