using System;
namespace Occupi.Models
{
    public class Event
    {
        public Event()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public DateTimeOffset DateCreated { get; set; }

    }
}
