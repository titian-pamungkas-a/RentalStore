using RentalStore.DTOs;
using RentalStore.Model;
using RentalStore.Repositories;

namespace RentalStore.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }
        public async Task AddFilm(Film input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            Film film = new Film
            {
                Name = input.Name,
                Description = input.Description,
                Synopsis = input.Synopsis,
                ReleaseDate = input.ReleaseDate
            };
            await _filmRepository.AddFilm(film);

        }

        public async Task<List<Film>> GetFilms()
        {
            var films = await _filmRepository.GetFilms();
            return films;
        }
    }
}
