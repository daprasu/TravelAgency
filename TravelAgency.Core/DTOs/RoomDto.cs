

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelAgency.Core.DTOs
{
    public partial class RoomDto
    {
        [Required(ErrorMessage = "The Id is required")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "The Room Code is required")]
        public string RoomCode { get; set; }
        [Required(ErrorMessage = "The base cost of the room is required")]
        public int BaseCost { get; set; }
        [Required(ErrorMessage = "The taxes of the room is required")]
        public int Taxes { get; set; }
        [Required(ErrorMessage = "The floor of the room is required")]
        public string Floor { get; set; }
        [Required(ErrorMessage = "The room status is required")]
        public bool? Enabled { get; set; }
        [Required(ErrorMessage = "The hotel id is required")]
        public int? HotelId { get; set; }
        [Required(ErrorMessage = "The room type id is required")]
        public int? RoomTypeId { get; set; }

    }
}
