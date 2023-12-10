using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string HotelName { get; set; }
        public int UserId { get; set; }
        public string Nit { get; set; }
        public bool? Enabled { get; set; }
        public string City { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
