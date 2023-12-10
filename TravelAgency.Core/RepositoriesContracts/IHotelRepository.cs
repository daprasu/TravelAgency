using TravelAgency.Core.Entities;

namespace TravelAgency.Core.RepositoriesContracts
{
    public interface IHotelRepository
    {
        void Insert(Hotel hotel);
        void Update(Hotel hotel);
        void UpdateState(int hotelId, bool state);
    }
}
