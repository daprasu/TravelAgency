using System.Collections.Generic;

#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string RoomEspecification { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
