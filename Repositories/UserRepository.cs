using Microsoft.EntityFrameworkCore;
using RentalStore.Data;
using RentalStore.Model;

namespace RentalStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentalStoreContext _context;
        public UserRepository(RentalStoreContext context)
        {
            _context = context;
        }
        public async Task AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(User user)
        {
            //await _context.Database.ExecuteSqlRawAsync("CALL add_user({0}, {1}, {2})", user.Name, user.Email, user.gender);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<User> GetUser(string name, string email)
        {
            var user = await _context.Users
                .Where(u => u.Name == name && u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null)
                return null;
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
