using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class GuestDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        [Required(ErrorMessage = "First surname is required")]
        public string FirstSurname { get; set; }
        public string? SecondSurname { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "Document type id is required")]
        public int? DocumentTypeId { get; set; }
        [Required(ErrorMessage = "Document number is required")]
        public int? DocumentNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public int? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Emergency contact is required")]
        public string EmergencyContact { get; set; }
        [Required(ErrorMessage = "Emergency number is required")]
        public int? EmergencyNumber { get; set; }
        [Required(ErrorMessage = "User id is required")]
        public int? UserId { get; set; }
    }
}
