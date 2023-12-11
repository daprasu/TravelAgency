
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Core.DTOs
{
    public partial class HotelDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }
        /// <summary>
        /// </summary>
        /// <example>Hotel Buena Vista</example>
        [Required(ErrorMessage = "Hotel Name is required")]
        public string HotelName { get; set; }
        /// <summary>
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "User Id is required")]
        public int? UserId { get; set; }
        /// <summary>
        /// </summary>
        /// <example>0123-45</example>
        [Required(ErrorMessage = "NIT is required")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "Hotel Status is required")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// </summary>
        /// <example>Bucaramanga</example>
        [Required(ErrorMessage = "Hotel city is required")]
        public string City { get; set; }
    }
}
