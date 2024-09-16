using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using System.Threading.Tasks;
using Internship_Netsol_ProductManagement_DotNetApi.Mappers;

namespace Internship_Netsol_ProductManagement_DotNetApi.BLL
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;

        public UserServices(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO userDto)
        {
            var userModel = userDto.ToModelFromDto();
            var createdUser = await _userRepo.CreateUserAsync(userModel);
            return createdUser.ToDtoFromModel();
        }

        public async Task<bool> UserAuthenticationAsync(string email, string password)
        {
            return await _userRepo.UserAuthenticationAsync(email, password);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            return user?.ToDtoFromModel();
        }
    }
}
