using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;
using TravelAngecy.Infraestructure.Data;

namespace TravelAngecy.Infraestructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        #region Fields
        private readonly AgenciaViajesSmartContext _context;
        #endregion

        #region Builders
        public ReservationRepository(AgenciaViajesSmartContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public void CreateReservation(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
        }

        public dynamic GetReservationByUserId(int userId)
        {
            var listReservation = _context.Reservation.Include(x => x.Room).ThenInclude(x => x.Hotel)
                        .Include(x => x.Room).ThenInclude(x => x.RoomType)
                        .Where(x => x.Room.Hotel.UserId.Equals(userId));
            return listReservation;
        }
        public Reservation GetReservationByReservationId(int reservationId)
        {
            var reservation = _context.Reservation.Include(x => x.Room).ThenInclude(x => x.Hotel)
                        .Include(x => x.Room).ThenInclude(x => x.RoomType)
                        .Include(x=> x.Guest)
                        .FirstOrDefault(x => x.Id.Equals(reservationId));
            return reservation;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
