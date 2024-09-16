using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Internship_Netsol_ProductManagement_DotNetApi.DTO
{
    public class CreateUserDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 10 character")]
        [MinLength(4, ErrorMessage = "Minimum Length is 4 character")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(10,ErrorMessage ="Maximum length is 10 character")]
        [MinLength(4,ErrorMessage ="Minimum Length is 4 character")]
        public string Password { get; set; } = string.Empty;
    }
}
