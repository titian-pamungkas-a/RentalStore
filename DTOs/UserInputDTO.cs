using RentalStore.Model;
using System.ComponentModel.DataAnnotations;

namespace RentalStore.DTOs
{
    public class UserInputDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string? AddressName { get; set; }
        [Required]
        public string? AddressNumber { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string GenderUser { get; set; }
    }
}
