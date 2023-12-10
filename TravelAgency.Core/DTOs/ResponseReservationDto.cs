using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class ResponseReservationDto
    {
        public ReservationDto Reservation { get; set; }
        public  RoomDto Room { get; set; }
        public  List<GuestDto> Guest { get; set; }

        public string HotelName { get; set; }
        public string RoomEspecification { get; set; }
    }
}
