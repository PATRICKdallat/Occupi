using System;

namespace PAT.Portable.EventArguments
{
    public class BarometerReadingChangedEventArgs : EventArgs
    {
        public double DegreesFromNorth { get; set; }
    }
}