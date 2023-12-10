#nullable disable

namespace TravelAgency.Core.Entities
{
    public partial class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public bool Gender { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentNumber { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public int EmergencyNumber { get; set; }
        public int UserId { get; set; }
        public int ReservationId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual User User { get; set; }
    }
}
