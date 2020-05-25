using System;

namespace PAT.Portable.EventArguments
{
    public class CompassReadingChangedEventArgs : EventArgs
    {
        public double DegreesFromNorth { get; set; }
    }
}