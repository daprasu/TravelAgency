

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelAgency.Core.DTOs
{
    public partial class RoomDto
    {
        [Required(ErrorMessage = "The Id is required")]
        public int? Id { get; set; }
        /// <summary>
        /// </summary>
        /// <example>504</example>
        [Required(ErrorMessage = "The Room Code is required")]
        public string RoomCode { get; set; }
        /// <summary>
        /// </summary>
        /// <example>150000</example>
        [Required(ErrorMessage = "The base cost of the room is required")]
        public int BaseCost { get; set; }
        /// <summary>
        /// </summary>
        /// <example>30000</example>
        [Required(ErrorMessage = "The taxes of the room is required")]
        public int Taxes { get; set; }
        /// <summary>
        /// </summary>
        /// <example>5</example>
        [Required(ErrorMessage = "The floor of the room is required")]
        public string Floor { get; set; }
        [Required(ErrorMessage = "The room status is required")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// </summary>
        /// <example>5</example>
        [Required(ErrorMessage = "The hotel id is required")]
        public int? HotelId { get; set; }
        /// <summary>
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "The room type id is required")]
        public int? RoomTypeId { get; set; }

    }
}
