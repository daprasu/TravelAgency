using System;
using System.Collections.Generic;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.RepositoriesContracts
{
    public interface IRoomRepository
    {
        void Insert(Room room);
        void Update(Room room);
        void UpdateState(int roomId, bool state);
        Room GetRoomById(int? roomId);
        List<Room> FilterRoom(DateTime startDate, DateTime endDate, int numberPeople, string city);
    }
}
