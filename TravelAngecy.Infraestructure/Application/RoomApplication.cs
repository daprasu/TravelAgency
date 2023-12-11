using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;

namespace TravelAngecy.Infraestructure.Application
{
    public class RoomApplication: IRoomApplication
    {
        #region Fields
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Builders
        public RoomApplication(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public ResponseQuery<bool> ManageRoom(RoomDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                var room = _mapper.Map<Room>(request);
                if (room.Id.Equals(0))
                {
                    _roomRepository.Insert(room);
                }
                else
                {
                    _roomRepository.Update(room);
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("System Error", false, ex.Message);
            }
            response.ResponseMessage("Successful", true);
            return response;
        }
        public ResponseQuery<bool> ChangeStateRoom(int roomId, bool state)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                _roomRepository.UpdateState(roomId, state);
            }
            catch (Exception ex)
            {
                response.ResponseMessage("System Error", false, ex.Message);
            }
            response.ResponseMessage("Successful", true);
            return response;
        }
        public ResponseQuery<List<ResponseRoomDto>> GetFilterRoom(DateTime startDate, DateTime endDate, int numberPeople, string city)
        {
            ResponseQuery<List<ResponseRoomDto>> response = new ResponseQuery<List<ResponseRoomDto>>();
            if (startDate < DateTime.Now)
            {
                response.ResponseMessage("the start date cannot be less to " + DateTime.Now.ToString(), false);
                return response;
            }
            try
            {
                var rooms = _roomRepository.FilterRoom(startDate, endDate, numberPeople, city);
                List<ResponseRoomDto> listRoom = rooms.Select(room => new ResponseRoomDto()
                {
                    Id = room.Id,
                    HotelName = room.Hotel.HotelName,
                    RoomEspecification = room.RoomType.RoomEspecification,
                    Capacity = room.RoomType.Capacity,
                    price = room.BaseCost + room.Taxes
                }).ToList();
                response.Result = listRoom;
            }
            catch (Exception ex)
            {
                response.ResponseMessage("System Error", false, ex.Message);
            }
            return response;
        }
        #endregion
    }
}
