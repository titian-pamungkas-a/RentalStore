using RentalStore.DTOs;
using RentalStore.Model;
using RentalStore.Repositories;

namespace RentalStore.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task AddRental(RentalInputDTO input)
        {
            Rental rental = new Rental
            {
                UserId = input.UserId,
                FilmId = input.FilmId,
                RentalDate = input.RentalDate,
                DeadlineDate = input.DeadlineDate
            };
            await _rentalRepository.AddRental(rental);
        }

        public async Task<List<ViewData>> GetRentals()
        {
            return await _rentalRepository.GetRentals();
        }
    }
}
