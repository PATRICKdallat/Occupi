using System;

namespace PAT.Services
{
    public class CompassReadingChangedEventArgs : EventArgs
    {
        public double DegreesFromNorth { get; set; }
    }
}