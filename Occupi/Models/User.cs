using System;
namespace Occupi.Portable.Models
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactInformationId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
