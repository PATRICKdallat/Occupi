using System;
using System.Numerics;

namespace PAT.Portable.EventArguments
{
    public class MagnetometerReadingChangedEventArgs : EventArgs
    {
        public Vector3 MagneticField { get; set; }
    }
}