using AutoMapper;
using System;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;

namespace TravelAngecy.Infraestructure.Application
{
    public class HotelApplication : IHotelApplication
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private const string CODE_ADMIN= "Admin";
        #endregion

        #region Builders
        public HotelApplication(IHotelRepository hotelRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public ResponseQuery<bool> ManageHotel(HotelDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            var administrador = _userRepository.GetUserByCode(request.UserId);
            if (administrador.Code.ToLower().Equals(CODE_ADMIN.ToLower()))
            {
                try
                {
                    var hotel = _mapper.Map<Hotel>(request);
                    if (hotel.Id.Equals(0))
                    {
                        _hotelRepository.Insert(hotel);
                    }
                    else
                    {
                        _hotelRepository.Update(hotel);
                    } 
                }
                catch (Exception ex)
                {
                    response.ResponseMessage("System Error", false, ex.Message);

                }
                response.ResponseMessage("Successful", true);
                return response;
            }
            else
            {
                response.ResponseMessage("This user could not access this function", false);
                return response;
            }
        }
        public ResponseQuery<bool> ChangeStateHotel(int hotelId, bool state)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                _hotelRepository.UpdateState(hotelId, state);
                response.ResponseMessage("Successful", true);
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
