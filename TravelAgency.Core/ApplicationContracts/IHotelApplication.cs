using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;

namespace TravelAgency.Core.ApplicationContracts
{
    public interface IHotelApplication
    {
        ResponseQuery<bool> ManageHotel(HotelDto request);
        ResponseQuery<bool> ChangeStateHotel(int hotelId, bool state);
    }
}
