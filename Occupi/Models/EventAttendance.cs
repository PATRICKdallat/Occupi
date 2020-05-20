using System;
namespace Occupi.Portable.Models
{
    public class EventAttendance
    {
        public EventAttendance()
        {
        }

        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
    }
}
