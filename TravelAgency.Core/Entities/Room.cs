using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class Room
    {
        public Room()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int BaseCost { get; set; }
        public int Taxes { get; set; }
        public string Floor { get; set; }
        public bool? Enabled { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
