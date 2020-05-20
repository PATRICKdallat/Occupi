using System;
namespace Occupi.Portable.Models
{
    public class Location
    {
        public Location()
        {
        }

        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string TownCity { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}
