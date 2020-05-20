using System;
using System.Numerics;

namespace PAT.Services
{
    public class GyroscopeReadingChangedEventArgs : EventArgs
    {
        public Vector3 AngularVelocity { get; set; }
    }
}