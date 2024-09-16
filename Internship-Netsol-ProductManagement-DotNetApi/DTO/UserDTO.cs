using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Internship_Netsol_ProductManagement_DotNetApi.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

     
        public string Email { get; set; } = string.Empty;

      
        public string Password { get; set; } = string.Empty;
    }
}
