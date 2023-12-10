using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;
using TravelAgency.Core.Entities;

namespace TravelAgency.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        #region Fields
        private readonly IReservationApplication _reservationApplication;
        #endregion

        #region Builders
        public ReservationController(IReservationApplication reservationApplication)
        {
            _reservationApplication = reservationApplication;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new Reservation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(ReservationController.CreateReservation))]
        public async Task<ResponseQuery<bool>> CreateReservation(ReservationRequestDto request)
        {
            return await Task.Run(() =>
            {
                return _reservationApplication.CreateReservation(request);
            });
        }

        /// <summary>
        /// Get the reservations assigned to the hotels
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ReservationController.GetReservationByUserId))]
        public async Task<ResponseQuery<List<ListReservationDto>>> GetReservationByUserId(int userId)
        {
            return await Task.Run(() =>
            {
                return _reservationApplication.GetReservationByUserId(userId);
            });
        }
        /// <summary>
        /// Get the reservation specification
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(ReservationController.GetReservationByReservationId))]
        public async Task<ResponseQuery<ResponseReservationDto>> GetReservationByReservationId(int reservationId)
        {
            return await Task.Run(() =>
            {
                return _reservationApplication.GetReservationByReservationId(reservationId);
            });
        }

        #endregion
    }
}
