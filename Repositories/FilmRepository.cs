using Microsoft.EntityFrameworkCore;
using RentalStore.Data;
using RentalStore.Model;

namespace RentalStore.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly RentalStoreContext _context;
        public FilmRepository(RentalStoreContext context)
        {
            _context = context;
        }
        public async Task AddFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Film>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }
    }
}
