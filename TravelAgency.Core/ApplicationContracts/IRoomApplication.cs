using System;
using System.Collections.Generic;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;

namespace TravelAgency.Core.ApplicationContracts
{
    public interface IRoomApplication
    {
        ResponseQuery<bool> ManageRoom(RoomDto request);
        ResponseQuery<bool> ChangeStateRoom(int roomId, bool state);
        ResponseQuery<List<ResponseRoomDto>> GetFilterRoom(DateTime startDate, DateTime endDate, int numberPeople, string city);
    }
}
