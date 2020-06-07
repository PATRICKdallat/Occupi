using System;
using System.Threading;
using PAT.Portable.Services;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public class SystemService : ISystemService
    {
        public async void Flashlight(bool on)
        {
            if (on)
            {
                await Xamarin.Essentials.Flashlight.TurnOnAsync();
            }
            else
            {
                await Xamarin.Essentials.Flashlight.TurnOffAsync();
            }
        }

        public string GetAppName() => AppInfo.Name;

        public string GetAppPackageName() => AppInfo.PackageName;

        public string GetAppBuildVersion() => AppInfo.BuildString;

        public string GetAppVersionNumber() => AppInfo.VersionString;

        public Version GetAppVersion() => AppInfo.Version;


        public void OpenAppSettings() => AppInfo.ShowSettingsUI();


        public double GetBatteryLevel() => Battery.ChargeLevel;

        public BatteryState GetBatteryState () => Battery.State;

        public BatteryPowerSource GetPowerSource() => Battery.PowerSource;

        public EnergySaverStatus IsEnergySaverEnabled() => Battery.EnergySaverStatus;


        public bool IsKeepScreenOnEnabled() => DeviceDisplay.KeepScreenOn;

        public DisplayInfo GetDeviceDisplayInformation() => DeviceDisplay.MainDisplayInfo;


        public string GetDeviceName() => DeviceInfo.Name;

        public string GetDeviceModel() => DeviceInfo.Model;

        public string GetDeviceManufacturer() => DeviceInfo.Manufacturer;

        public string GetDeviceVersionString() => DeviceInfo.VersionString;


        public AppTheme GetDeviceTheme() => AppInfo.RequestedTheme;

        public Version GetDeviceVersion() => DeviceInfo.Version;

        public DeviceIdiom GetDeviceType() => DeviceInfo.Idiom;

        public DevicePlatform GetDevicePlatform() => DeviceInfo.Platform;


        public async void Speak(string textToSpeech, CancellationToken cancellationToken)
            => await TextToSpeech.SpeakAsync(textToSpeech,cancellationToken);

        public void Vibrate() => Vibration.Vibrate();

        public void Vibrate(double duration) => Vibration.Vibrate(duration);

        public void Vibrate(TimeSpan timeSpan) => Vibration.Vibrate(timeSpan);
    }
}
