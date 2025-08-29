using RentalStore.Model;

namespace RentalStore.Repositories
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetFilms();
        Task AddFilm(Film film);
    }
}
