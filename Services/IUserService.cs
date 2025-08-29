using RentalStore.DTOs;
using RentalStore.Model;

namespace RentalStore.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task AddUser(UserInputDTO input);
        Task<List<City>> GetCities();
    }
}
