using System.ComponentModel.DataAnnotations;

namespace RentalStore.DTOs
{
    public class RentalInputDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FilmId
        {
            get; set;
        }
        [Required]
        public DateOnly RentalDate { get; set; }
        [Required]
        public DateOnly DeadlineDate { get; set; }
    }
}
