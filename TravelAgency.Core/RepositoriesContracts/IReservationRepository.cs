using System.Collections.Generic;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.RepositoriesContracts
{
    public interface IReservationRepository
    {
        void CreateReservation(Reservation reservation);
        List<Reservation> GetReservationByUserId(int userId);
        Reservation GetReservationByReservationId(int reservationId);
        void Save();

    }
}
