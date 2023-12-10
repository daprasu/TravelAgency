using System.Collections.Generic;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;
using TravelAngecy.Infraestructure.Data;

namespace TravelAngecy.Infraestructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        #region Fields
        private readonly AgenciaViajesSmartContext _context;
        #endregion

        #region Builders
        public GuestRepository(AgenciaViajesSmartContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public void CreateGuestByList(List<Guest> guest)
        {
            _context.Guest.AddRange(guest);
        }
        #endregion
    }
}
