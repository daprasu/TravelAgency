using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;
using TravelAngecy.Infraestructure.Data;
using TravelAngecy.Infraestructure.Helpers;

namespace TravelAngecy.Infraestructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        #region Fields
        private readonly AgenciaViajesSmartContext _context;
        #endregion

        #region Builders
        public RoomRepository(AgenciaViajesSmartContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public void Insert(Room room)
        {
            _context.Room.Add(room);
            _context.SaveChanges();
        }

        public void Update(Room room)
        {
            var roomlDataBase = _context.Room.FirstOrDefault(x => x.Id.Equals(room.Id));
            FrammeworkTypeUtility.SetProperties(room, roomlDataBase);
            _context.SaveChanges();
        }
        public void UpdateState(int roomId, bool state)
        {
            var roomlDataBase = _context.Room.FirstOrDefault(x => x.Id.Equals(roomId));
            roomlDataBase.Enabled = state;
            _context.Update(roomlDataBase);
            _context.SaveChanges();
        }
        public Room GetRoomById(int? roomId)
        {
            var room = _context.Room.Include(x=> x.RoomType).Include(x=> x.Hotel).Where(x=> x.Id.Equals(roomId)).FirstOrDefault();
            return room;
        }
        public List<Room> FilterRoom(DateTime startDate, DateTime endDate, int numberPeople, string city)
        {
            var reservation = _context.Reservation.Where(x=> x.StartDate.Date >= startDate.Date && x.EndDate.Date <= endDate.Date).Select(x=> x.RoomId).ToList();
            var listRoom = _context.Room.Include(x => x.RoomType)
                .Include(x => x.Hotel)
                .Include(x => x.Reservation)
                .Where(x => x.Hotel.City.ToLower().Equals(city.ToLower()) && x.RoomType.Capacity >= numberPeople && x.Enabled.Equals(true)).ToList();

            listRoom.RemoveAll(z => reservation.Contains(z.Id));

            return listRoom;
        }
        #endregion
    }
}
