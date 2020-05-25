using System;

namespace PAT.Portable.EventArguments
{
    public class ShakeDetectionReadingChangedEventArgs : EventArgs
    {
        public DateTimeOffset ShakeDetectedTime { get; set; }
    }
}