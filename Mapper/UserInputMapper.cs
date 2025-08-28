using RentalStore.DTOs;
using RentalStore.Model;

namespace RentalStore.Mapper
{
    public class UserInputMapper
    {
        public User ToUser(UserInputDTO input)
        {
            return new User
            {
                Name = input.Name,
                Email = input.Email,
            };
        }
    }
}
