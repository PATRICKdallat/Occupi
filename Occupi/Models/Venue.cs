using System;
namespace Occupi.Portable.Models
{
    public class Venue
    {
        public Venue()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int HostedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int ContactInformationId { get; set; }
    }
}
