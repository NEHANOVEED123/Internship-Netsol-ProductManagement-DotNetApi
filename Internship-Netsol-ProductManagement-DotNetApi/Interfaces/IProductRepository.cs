using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;
using Internship_Netsol_ProductManagement_DotNetApi.Models;

namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductDTO productDTO);
        Task<Product?> DeleteAsync(int id);
        Task<bool> ProductExists(int id);
    }
}
