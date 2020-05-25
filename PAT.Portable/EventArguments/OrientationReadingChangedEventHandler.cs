using System;
using System.Numerics;

namespace PAT.Portable.EventArguments
{
    public class OrientationReadingChangedEventArgs : EventArgs
    {
        public Quaternion Orientation { get; set; }
    }
}