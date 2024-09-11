using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;

namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts(ProductQueryObject query);
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO);
        Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProduct(int id);
    }
}
