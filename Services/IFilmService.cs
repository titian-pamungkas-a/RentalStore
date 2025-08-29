using RentalStore.DTOs;
using RentalStore.Model;

namespace RentalStore.Services
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
        Task AddFilm(Film input);
    }
}
