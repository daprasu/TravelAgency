using System.Linq;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;
using TravelAngecy.Infraestructure.Data;
using TravelAngecy.Infraestructure.Helpers;

namespace TravelAngecy.Infraestructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        #region Fields
        private readonly AgenciaViajesSmartContext _context;
        #endregion

        #region Builders
        public HotelRepository(AgenciaViajesSmartContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public void Insert(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel hotel)
        {
            var hotelDataBase = _context.Hotel.FirstOrDefault(x => x.Id.Equals(hotel.Id));
            FrammeworkTypeUtility.SetProperties(hotel, hotelDataBase);
            _context.SaveChanges();
        }
        public void UpdateState(int hotelId, bool state)
        {
            var hotelDataBase = _context.Hotel.FirstOrDefault(x => x.Id.Equals(hotelId));
            hotelDataBase.Enabled = state;
            _context.Update(hotelDataBase);
            _context.SaveChanges();
        }
        #endregion
    }
}
