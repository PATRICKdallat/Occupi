using System;
using System.Numerics;

namespace PAT.Services
{
    public class MagnetometerReadingChangedEventArgs : EventArgs
    {
        public Vector3 MagneticField { get; set; }
    }
}