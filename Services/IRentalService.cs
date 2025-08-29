using RentalStore.DTOs;

namespace RentalStore.Services
{
    public interface IRentalService
    {
        Task AddRental(RentalInputDTO input);
        Task<List<ViewData>> GetRentals();
    }
}
