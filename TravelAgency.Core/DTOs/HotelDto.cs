
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class HotelDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Hotel Name is required")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "User Id is required")]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "NIT is required")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "Hotel Status is required")]
        public bool? Enabled { get; set; }
        [Required(ErrorMessage = "Hotel city is required")]
        public string City { get; set; }
    }
}
