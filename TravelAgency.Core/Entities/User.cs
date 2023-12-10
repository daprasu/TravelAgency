using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Guest = new HashSet<Guest>();
            Hotel = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Guest> Guest { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }
    }
}
