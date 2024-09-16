using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.Models;

namespace Internship_Netsol_ProductManagement_DotNetApi.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDtoFromModel(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static User ToModelFromDto(this CreateUserDTO userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}
