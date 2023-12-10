using System.Collections.Generic;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.RepositoriesContracts
{
    public interface IGuestRepository
    {
        void CreateGuestByList(List<Guest> Request);
    }
}
