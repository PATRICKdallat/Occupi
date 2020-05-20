using System;
using System.Numerics;

namespace PAT.Services
{
    public class AccelerometerReadingChangedEventArgs : EventArgs
    {
        public Vector3 Acceleration { get; set; }
    }
}