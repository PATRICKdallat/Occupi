using System;
using System.Numerics;

namespace PAT.Services
{
    public class ShakeDetectionReadingChangedEventArgs : EventArgs
    {
        public DateTimeOffset ShakeDetectedTime { get; set; }
    }
}