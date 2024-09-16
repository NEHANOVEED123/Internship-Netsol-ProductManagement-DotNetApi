using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using System.Threading.Tasks;

namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface IUserServices
    {
        public Task<UserDTO> CreateUserAsync(CreateUserDTO userDto);
        public Task<bool> UserAuthenticationAsync(string email, string password);
        public Task<UserDTO> GetUserByIdAsync(int id);
    }
}
