using Internship_Netsol_ProductManagement_DotNetApi.DAL;
using Internship_Netsol_ProductManagement_DotNetApi.Models;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Internship_Netsol_ProductManagement_DotNetApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserAuthenticationAsync(string email, string password)
        {
            return await _context.Users.AnyAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
