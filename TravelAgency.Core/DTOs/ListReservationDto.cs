using System;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class ListReservationDto
    {
        /// <summary>
        /// </summary>
        /// <example>1</example>
        public int? Id { get; set; }
        public string HotelName { get; set; }
        public int? Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberPeople { get; set; }
        public string RoomEspecification { get; set; }
        public string RoomCode { get; set; }
    }
}
