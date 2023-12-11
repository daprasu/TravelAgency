using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class ReservationDto
    {
        [Required(ErrorMessage = "The Id is required")]
        public int? Id { get; set; }
        /// <summary>
        /// </summary>
        /// <example>100000</example>
        [Required(ErrorMessage = "The cost of the reservation is required")]
        public int? Cost { get; set; }
        /// <summary>
        /// </summary>
        /// <example>2023-12-18</example>
        [Required(ErrorMessage = "The reservation start date required")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// </summary>
        /// <example>2023-12-19</example>
        [Required(ErrorMessage = "The reservation end date is required")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "The number of people is required")]
        public int? NumberPeople { get; set; }
        /// <summary>
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "The room Id is required")]
        public int? RoomId { get; set; }
    }
}
