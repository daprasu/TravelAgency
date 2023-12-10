using System;
using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class Reservation
    {
        public Reservation()
        {
            Guest = new HashSet<Guest>();
        }

        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberPeople { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Guest> Guest { get; set; }
    }
}
