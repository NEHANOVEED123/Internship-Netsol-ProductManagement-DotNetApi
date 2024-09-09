using System.ComponentModel.DataAnnotations;


namespace Internship_Netsol_ProductManagement_DotNetApi.DTO
{
    public class CreateProductDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name character must be minimum 3")]
        [MaxLength(10, ErrorMessage = "Name character cannot be over maximum 10")]
        public string Name { get; set; } = string.Empty;


        [Required]
        [MinLength(3, ErrorMessage = "Name character must be minimum 3")]
        [MaxLength(100, ErrorMessage = "Name character cannot be over maximum 100")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1000, 100000)]
        public double? Price { get; set; }


    }
}
