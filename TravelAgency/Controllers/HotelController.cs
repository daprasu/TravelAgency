using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;

namespace TravelAgency.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        #region Fields
        private readonly IHotelApplication _hotelApplication;
        #endregion

        #region Builders
        public HotelController(IHotelApplication hotelApplication)
        {
            _hotelApplication = hotelApplication;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create or edit a hotel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(HotelController.ManageHotel))]
        public async Task<ResponseQuery<bool>> ManageHotel(HotelDto request)
        {
            return await Task.Run(() =>
            {
                return _hotelApplication.ManageHotel(request);
            });
        }
        /// <summary>
        /// Allows you to enable or disable a hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(HotelController.ChangeStateHotel))]
        public async Task<ResponseQuery<bool>> ChangeStateHotel(int hotelId,bool state)
        {
            return await Task.Run(() =>
            {
                return _hotelApplication.ChangeStateHotel(hotelId, state);
            });
        }
        #endregion
    }
}
