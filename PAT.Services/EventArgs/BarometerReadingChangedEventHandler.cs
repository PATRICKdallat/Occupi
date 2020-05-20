using System;

namespace PAT.Services
{
    public class BarometerReadingChangedEventArgs : EventArgs
    {
        public double DegreesFromNorth { get; set; }
    }
}