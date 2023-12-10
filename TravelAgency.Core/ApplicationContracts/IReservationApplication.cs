using System.Collections.Generic;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.ApplicationContracts
{
    public interface IReservationApplication
    {
        ResponseQuery<bool> CreateReservation(ReservationRequestDto request);
        ResponseQuery<List<ListReservationDto>> GetReservationByUserId(int userId);
        ResponseQuery<ResponseReservationDto> GetReservationByReservationId(int reservationId);


    }
}
