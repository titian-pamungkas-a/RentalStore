using RentalStore.Model;

namespace RentalStore.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task AddUser(User user);
        Task<User> GetUser(string name, string email);
        Task AddAddress(Address address);
        Task<List<City>> GetCities();
    }
}
