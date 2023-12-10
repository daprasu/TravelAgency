using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class ReservationDto
    {
        /// <summary>
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "The Id is required")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "The cost of the reservation is required")]
        public int? Cost { get; set; }
        [Required(ErrorMessage = "The reservation start date required")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "The reservation end date is required")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "The number of people is required")]
        public int? NumberPeople { get; set; }
        [Required(ErrorMessage = "The room Id is required")]
        public int? RoomId { get; set; }
    }
}
