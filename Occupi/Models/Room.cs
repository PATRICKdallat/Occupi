using System;
namespace Occupi.Models
{
    public class Room
    {
        public Room()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public int VenueId { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int HostedBy { get; set; }
        public int ContactInformationId { get; set; }
    }
}
