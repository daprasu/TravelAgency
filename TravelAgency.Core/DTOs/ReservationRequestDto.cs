using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public class ReservationRequestDto
    {
        [Required]
        public ReservationDto Reservation { get; set; }
        [Required]
        public List<GuestDto> ListGuest { get; set; }
    }
}
