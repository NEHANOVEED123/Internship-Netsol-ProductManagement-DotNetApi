using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.Models;

namespace Internship_Netsol_ProductManagement_DotNetApi.Mappers
{
    public static class ProductMappers
    {
        public static ProductDTO ToProductDto(this Product productModel) // Extension method to map a Person model to a PersonDTO.
        {
            return new ProductDTO
            {
                Id = productModel.Id, // Maps the ID.
                Name = productModel.Name, // Maps the Name.
                Price = productModel.Price, // Maps the Salary.
                Description = productModel.Description
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDTO productDto) // Extension method to map a CreatePersonDTO to a Person model.
        {
            return new Product
            {
                Name = productDto.Name, // Maps the Name.
                Description = productDto.Description,
                Price = productDto.Price ?? 0.0 // Maps the Salary.
                                                // Maps the Market Capital.
            };
        }
    }
}
