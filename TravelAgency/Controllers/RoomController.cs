using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;

namespace TravelAgency.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        #region Fields
        private readonly IRoomApplication _roomApplication;
        #endregion

        #region Builders
        public RoomController(IRoomApplication roomApplication)
        {
            _roomApplication = roomApplication;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Create or edit a room
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(RoomController.ManageRoom))]
        public async Task<ResponseQuery<bool>> ManageRoom(RoomDto request)
        {
            return await Task.Run(() =>
            {
                return _roomApplication.ManageRoom(request);
            });
        }
        /// <summary>
        /// Allows you to enable or disable a room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(RoomController.ChangeStateRoom))]
        public async Task<ResponseQuery<bool>> ChangeStateRoom(int roomId, bool state)
        {
            return await Task.Run(() =>
            {
                return _roomApplication.ChangeStateRoom(roomId, state);
            });
        }
        /// <summary>
        /// Get the room available with the search variable
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="numberPeople"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(RoomController.GetFilterRoom))]
        public async Task<ResponseQuery<List<ResponseRoomDto>>> GetFilterRoom(DateTime startDate, DateTime endDate, int numberPeople, string city)
        {
            return await Task.Run(() =>
            {
                return _roomApplication.GetFilterRoom(startDate, endDate, numberPeople, city);
            });
        }
        #endregion
    }
}
