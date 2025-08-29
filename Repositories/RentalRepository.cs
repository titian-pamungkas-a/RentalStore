using Microsoft.EntityFrameworkCore;
using RentalStore.Data;
using RentalStore.DTOs;
using RentalStore.Model;

namespace RentalStore.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalStoreContext _context;
        public RentalRepository(RentalStoreContext context)
        {
            _context = context;
        }

        public async Task AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ViewData>> GetRentals()
        {
            return await _context.ViewDatas.ToListAsync();
        }
    }
}
