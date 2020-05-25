using System;
namespace Occupi.Models
{
    public class Facility
    {
        public Facility()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
