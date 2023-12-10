using AutoMapper;
using System.Collections.Generic;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.Entities;

namespace TravelAgency.Core.Automapper
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            CreateMap<DocumentTypeDto, DocumentType>().ReverseMap();
            CreateMap<GuestDto, Guest>().ReverseMap();
            CreateMap<HotelDto, Hotel>().ReverseMap();
            CreateMap<ReservationDto, Reservation>().ReverseMap();
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<RoomTypeDto, RoomType>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }

    }
}
