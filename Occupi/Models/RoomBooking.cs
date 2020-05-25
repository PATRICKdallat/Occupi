using System;
namespace Occupi.Models
{
    public class RoomBooking
    {
        public RoomBooking()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public int NoOfAttendees { get; set; }
        public string SpecialRequirements { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
