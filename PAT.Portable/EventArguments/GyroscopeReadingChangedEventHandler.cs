using System;
using System.Numerics;

namespace PAT.Portable.EventArguments
{
    public class GyroscopeReadingChangedEventArgs : EventArgs
    {
        public Vector3 AngularVelocity { get; set; }
    }
}