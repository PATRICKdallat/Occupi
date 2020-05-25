using System;
using System.Numerics;

namespace PAT.Portable.EventArguments
{
    public class AccelerometerReadingChangedEventArgs : EventArgs
    {
        public Vector3 Acceleration { get; set; }
    }
}