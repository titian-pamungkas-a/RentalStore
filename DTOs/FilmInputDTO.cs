using System.ComponentModel.DataAnnotations;

namespace RentalStore.DTOs
{
    public class FilmInputDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Synopsis { get; set; }

        public DateOnly ReleaseDate { get; set; } = DateOnly.MaxValue;
    }
}
