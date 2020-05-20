using System;
using Xamarin.Essentials;

namespace PAT.Services
{
    public interface ISensorService : IDisposable
    {
        event EventHandler ShakeDetectionReadingChanged;
        event CompassReadingChangeEventHandler CompassReadingChanged;
        event BarometerReadingChangeEventHandler BarometerReadingChanged;
        event MagnetometerReadingChangeEventHandler MagnetometerReadingChanged;
        event AccelerometerReadingChangeEventHandler AccelerometerReadingChanged;
        event GyroscopeReadingChangeEventHandler GyroscopeReadingChanged;
        event OrientationReadingChangeEventHandler OrientationReadingChanged;

        void CompassStart(SensorSpeed speed);
        void CompassStop();

        void BarometerStart(SensorSpeed speed);
        void BarometerStop();

        void MagnetometerStart(SensorSpeed speed);
        void MagnetometerStop();

        void AccelerometerStart(SensorSpeed speed);
        void AccelerometerStop();

        void ShakeDetectionStart(SensorSpeed speed);
        void ShakeDetectionStop();

        void GyroscopeStart(SensorSpeed speed);
        void GyroscopeStop();

        void OrientationStart(SensorSpeed speed);
        void OrientationStop();
    }

    public delegate void CompassReadingChangeEventHandler(object sender, CompassReadingChangedEventArgs e);
    public delegate void BarometerReadingChangeEventHandler(object sender, BarometerReadingChangedEventArgs e);
    public delegate void MagnetometerReadingChangeEventHandler(object sender, MagnetometerReadingChangedEventArgs e);
    public delegate void AccelerometerReadingChangeEventHandler(object sender, AccelerometerReadingChangedEventArgs e);
    public delegate void ShakeDectionReadingChangeEventHandler(object sender, ShakeDetectionReadingChangedEventArgs e);
    public delegate void GyroscopeReadingChangeEventHandler(object sender, GyroscopeReadingChangedEventArgs e);
    public delegate void OrientationReadingChangeEventHandler(object sender, OrientationReadingChangedEventArgs e);
}