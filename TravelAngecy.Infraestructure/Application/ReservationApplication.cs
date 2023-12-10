using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.DTOs.Response;
using TravelAgency.Core.Entities;
using TravelAgency.Core.RepositoriesContracts;

namespace TravelAngecy.Infraestructure.Application
{
    public class ReservationApplication : IReservationApplication
    {
        #region Fields
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly string EMAIL_SEND = "daprasu25@gmail.com";
        private readonly string PASSWORD_SEND = "Cristian_93";
        #endregion

        #region Builders
        public ReservationApplication(IReservationRepository reservationRepository, IRoomRepository roomRepository, IGuestRepository guestRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public ResponseQuery<bool> CreateReservation(ReservationRequestDto request)
        {
            ResponseQuery<bool> response = new ResponseQuery<bool>();
            try
            {
                var room = _roomRepository.GetRoomById(request.Reservation.RoomId);
                if (request.Reservation.NumberPeople <= room.RoomType.Capacity)
                {
                    try
                    {
                        // Save the reservation and the guests

                        var listGuest = _mapper.Map<List<Guest>>(request.ListGuest);
                        var reservation = _mapper.Map<Reservation>(request.Reservation);
                        reservation.Guest = listGuest;
                        _reservationRepository.CreateReservation(reservation);

                        // Send Email
                        string body = "Hello " + reservation.Guest.FirstOrDefault().FirstName + " " + reservation.Guest.FirstOrDefault().FirstSurname + ".\n\nBelow you can find the details of your reservation:\n\n" +
                            "Room type: " + reservation.Room.RoomType.RoomEspecification + ".\n\nArrival date: " + reservation.StartDate + ".\n\nExit date: " + reservation.EndDate + ".\n\nNumber of guests: " + reservation.NumberPeople;
                       
                        string subject = "Reservation confirmation in the hotel " + room.Hotel.HotelName;
                        
                        SendEmail( reservation.Guest.FirstOrDefault().Email, subject, body);

                        // Save Changes
                        _reservationRepository.Save();
                        response.ResponseMessage("reservation created successfully, in a few moments you should receive an email with the reservation information.", true);
                    }
                    catch (Exception ex)
                    {
                        response.ResponseMessage("System Error", false, ex.Message);
                    }
                }
                else
                {
                    response.ResponseMessage("the guest number is greater than the room capacity", false);
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("System Error", false, ex.Message);
            }
            return response;
        }
        public ResponseQuery<List<ListReservationDto>> GetReservationByUserId(int userId)
        {
            ResponseQuery<List<ListReservationDto>> response = new ResponseQuery<List<ListReservationDto>>();
            List<ListReservationDto> listReservations = new List<ListReservationDto>();
            var reservations = _reservationRepository.GetReservationByUserId(userId);
            foreach (var reservation in reservations)
            {
                ListReservationDto listReservation = new ListReservationDto()
                {
                    Id = reservation.Id,
                    HotelName = reservation.Room.Hotel.HotelName,
                    Cost = reservation.Cost,
                    RoomEspecification = reservation.Room.RoomType.RoomEspecification,
                    RoomCode = reservation.Room.RoomCode,
                    NumberPeople = reservation.NumberPeople,
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate,
                };
                listReservations.Add(listReservation);
            }
            response.ResponseMessage("Susccefull", true);
            response.Result = listReservations;
            return response;
        }
        public ResponseQuery<ResponseReservationDto> GetReservationByReservationId(int reservationId)
        {
            ResponseQuery<ResponseReservationDto> response = new ResponseQuery<ResponseReservationDto>();
            var reservation = _reservationRepository.GetReservationByReservationId(reservationId);
            ReservationDto reservationDto = new ReservationDto()
            {
                Id = reservation.Id,
                Cost = reservation.Cost,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                NumberPeople = reservation.NumberPeople
            };
            RoomDto roomDto = new RoomDto()
            {
                Id= reservation.Room.Id,
                RoomCode= reservation.Room.RoomCode,
                BaseCost = reservation.Room.BaseCost,
                Taxes = reservation.Room.Taxes,
                Floor = reservation.Room.Floor,
                Enabled = reservation.Room.Enabled
            };
            List<GuestDto> listGuest = reservation.Guest.Select(guest=> new GuestDto()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                SecondName = guest.SecondName,
                FirstSurname = guest.FirstSurname,
                SecondSurname = guest.SecondSurname,
                Gender= guest.Gender,
                DocumentTypeId = guest.DocumentTypeId,
                DocumentNumber = guest.DocumentNumber, 
                Email = guest.Email,
                PhoneNumber = guest.PhoneNumber,
                EmergencyContact = guest.EmergencyContact,
                EmergencyNumber = guest.EmergencyNumber,
                UserId = guest.UserId
            }).ToList();
            ResponseReservationDto responseReservation = new ResponseReservationDto()
            {
                Reservation = reservationDto,
                Room = roomDto,
                RoomEspecification = reservation.Room.RoomType.RoomEspecification,
                HotelName = reservation.Room.Hotel.HotelName,
                Guest = listGuest
            };
            response.ResponseMessage("Susccefull", true);
            response.Result = responseReservation;
            return response;
        }

        public void SendEmail(string guestEmail, string subject, string body)
        {
            // Configura la información del servidor SMTP
            var smtpCliente = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EMAIL_SEND, PASSWORD_SEND),
                EnableSsl = true,
            };

            // Configura el correo electrónico
            var message = new MailMessage
            {
                From = new MailAddress(EMAIL_SEND),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            // Agrega el destinatario
            message.To.Add(guestEmail);

            message.CC.Add(EMAIL_SEND);

            // Envía el correo electrónico
            smtpCliente.Send(message);
        }
        #endregion
    }
}
