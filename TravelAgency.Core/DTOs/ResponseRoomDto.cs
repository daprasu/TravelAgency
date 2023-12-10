

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelAgency.Core.DTOs
{
    public partial class ResponseRoomDto
    {

        public int Id { get; set; }
        public string HotelName { get; set; }
        public int Capacity { get; set; }
        public string RoomEspecification { get; set; }
        public int price { get; set; }
    }
}
