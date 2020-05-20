using System;
using PAT.Services;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public class SensorService : ISensorService
    {
        public event CompassReadingChangeEventHandler CompassReadingChanged;
        public event BarometerReadingChangeEventHandler BarometerReadingChanged;
        public event MagnetometerReadingChangeEventHandler MagnetometerReadingChanged;
        public event AccelerometerReadingChangeEventHandler AccelerometerReadingChanged;
        public event EventHandler ShakeDetectionReadingChanged;
        public event GyroscopeReadingChangeEventHandler GyroscopeReadingChanged;
        public event OrientationReadingChangeEventHandler OrientationReadingChanged;


        public void CompassStart(SensorSpeed speed)
        {
            Compass.ReadingChanged += Compass_ReadingChanged;

            if (!Compass.IsMonitoring)
                Compass.Start(speed);
        }

        public void BarometerStart(SensorSpeed speed)
        {
            Barometer.ReadingChanged += Barometer_ReadingChanged;

            if (!Barometer.IsMonitoring)
                Barometer.Start(speed);
        }

        public void MagnetometerStart(SensorSpeed speed)
        {
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;

            if (!Magnetometer.IsMonitoring)
                Magnetometer.Start(speed);
        }

        public void AccelerometerStart(SensorSpeed speed)
        {
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

            if (!Accelerometer.IsMonitoring)
                Accelerometer.Start(speed);
        }

        public void ShakeDetectionStart(SensorSpeed speed)
        {
            Accelerometer.ShakeDetected += ShakeDetection_ReadingChanged;

            if (!Accelerometer.IsMonitoring)
                Accelerometer.Start(speed);
        }

        public void GyroscopeStart(SensorSpeed speed)
        {
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;

            if (!Gyroscope.IsMonitoring)
                Gyroscope.Start(speed);
        }

        public void OrientationStart(SensorSpeed speed)
        {
            OrientationSensor.ReadingChanged += Orientation_ReadingChanged;

            if (!OrientationSensor.IsMonitoring)
                OrientationSensor.Start(speed);
        }


        public void CompassStop()
        {
            if (Compass.IsMonitoring)
                Compass.Stop();

            Compass.ReadingChanged -= Compass_ReadingChanged;
        }

        public void BarometerStop()
        {
            if (Barometer.IsMonitoring)
                Barometer.Stop();

            Barometer.ReadingChanged -= Barometer_ReadingChanged;
        }

        public void MagnetometerStop()
        {
            if (Magnetometer.IsMonitoring)
                Magnetometer.Stop();

            Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
        }

        public void AccelerometerStop()
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();

            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
        }

        public void ShakeDetectionStop()
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();

            Accelerometer.ShakeDetected -= ShakeDetection_ReadingChanged;
        }

        public void GyroscopeStop()
        {
            if (Gyroscope.IsMonitoring)
                Gyroscope.Stop();

            Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
        }

        public void OrientationStop()
        {
            if (OrientationSensor.IsMonitoring)
                OrientationSensor.Stop();

            OrientationSensor.ReadingChanged -= Orientation_ReadingChanged;
        }


        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var eventArgs = new CompassReadingChangedEventArgs();
            eventArgs.DegreesFromNorth = e.Reading.HeadingMagneticNorth;
            OnCompassReadingChanged(eventArgs);
        }

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            var eventArgs = new BarometerReadingChangedEventArgs();
            eventArgs.DegreesFromNorth = e.Reading.PressureInHectopascals;
            OnBarometerReadingChanged(eventArgs);
        }

        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var eventArgs = new MagnetometerReadingChangedEventArgs();
            eventArgs.MagneticField = e.Reading.MagneticField;
            OnMagnetometerReadingChanged(eventArgs);
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var eventArgs = new AccelerometerReadingChangedEventArgs();
            eventArgs.Acceleration = e.Reading.Acceleration;
            OnAccelerometerReadingChanged(eventArgs);
        }

        private void ShakeDetection_ReadingChanged(object sender, EventArgs e)
        {
            var eventArgs = new ShakeDetectionReadingChangedEventArgs();
            eventArgs.ShakeDetectedTime = DateTimeOffset.UtcNow;
            OnShakeDetectionReadingChanged(eventArgs);
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var eventArgs = new GyroscopeReadingChangedEventArgs();
            eventArgs.AngularVelocity = e.Reading.AngularVelocity;
            OnGyroscopeReadingChanged(eventArgs);
        }

        private void Orientation_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var eventArgs = new OrientationReadingChangedEventArgs();
            eventArgs.Orientation = e.Reading.Orientation;
            OnOrientationReadingChanged(eventArgs);
        }


        public void OnCompassReadingChanged(CompassReadingChangedEventArgs e)
        {
            CompassReadingChanged?.Invoke(this, e);
        }

        public void OnBarometerReadingChanged(BarometerReadingChangedEventArgs e)
        {
            BarometerReadingChanged?.Invoke(this, e);
        }

        public void OnMagnetometerReadingChanged(MagnetometerReadingChangedEventArgs e)
        {
            MagnetometerReadingChanged?.Invoke(this, e);
        }

        public void OnAccelerometerReadingChanged(AccelerometerReadingChangedEventArgs e)
        {
            AccelerometerReadingChanged?.Invoke(this, e);
        }

        public void OnShakeDetectionReadingChanged(EventArgs e)
        {
            ShakeDetectionReadingChanged?.Invoke(this, e);
        }

        public void OnGyroscopeReadingChanged(GyroscopeReadingChangedEventArgs e)
        {
            GyroscopeReadingChanged?.Invoke(this, e);
        }

        public void OnOrientationReadingChanged(OrientationReadingChangedEventArgs e)
        {
            OrientationReadingChanged?.Invoke(this, e);
        }


        public void Dispose()
        {
            Compass.ReadingChanged -= Compass_ReadingChanged;
            Barometer.ReadingChanged -= Barometer_ReadingChanged;
            Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.ShakeDetected -= ShakeDetection_ReadingChanged;
            Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
            OrientationSensor.ReadingChanged -= Orientation_ReadingChanged;
        }
    }
}
