using System;
using System.Numerics;

namespace PAT.Services
{
    public class OrientationReadingChangedEventArgs : EventArgs
    {
        public Quaternion Orientation { get; set; }
    }
}