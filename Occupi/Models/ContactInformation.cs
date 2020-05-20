using System;
namespace Occupi.Portable.Models
{
    public class ContactInformation
    {
        public ContactInformation()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
