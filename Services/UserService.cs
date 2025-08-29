using RentalStore.DTOs;
using RentalStore.Model;
using RentalStore.Repositories;

namespace RentalStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUser(UserInputDTO input)
        {
            if (input == null) 
                throw new ArgumentNullException(nameof(input));
            User user = new User
            {
                Name = input.Name,
                Email = input.Email,
                gender = input.GenderUser
            };
            await _userRepository.AddUser(user);
            user = await _userRepository.GetUser(input.Name, input.Email);
            Address address = new Address
            {
                UserId = user.Id,
                Name = input.AddressName,
                Num = input.AddressNumber,
                CityId = input.CityId
            };
            await _userRepository.AddAddress(address);
        }

        public async Task<List<City>> GetCities()
        {
            return await _userRepository.GetCities();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
    }
}
