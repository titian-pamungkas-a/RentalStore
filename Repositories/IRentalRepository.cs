using RentalStore.DTOs;
using RentalStore.Model;

namespace RentalStore.Repositories
{
    public interface IRentalRepository
    {
        Task<List<ViewData>> GetRentals();
        Task AddRental(Rental rental);
    }
}
