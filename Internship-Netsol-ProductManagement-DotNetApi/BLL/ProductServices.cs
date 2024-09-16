using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Mappers;

namespace Internship_Netsol_ProductManagement_DotNetApi.BLL
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepo;

        public ProductServices(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<ProductDTO>> GetAllProducts(ProductQueryObject query)
        {
            var products = await _productRepo.GetAllAsync(query);
            return products.Select(p => p.ToProductDto()).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return product?.ToProductDto();
        }

        public async Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO)
        {
            var productModel = createProductDTO.ToProductFromCreateDto();
            var createdProduct = await _productRepo.CreateAsync(productModel);
            return createdProduct.ToProductDto();
        }

        public async Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO updateProductDTO)
        {
            var updatedProduct = await _productRepo.UpdateAsync(id, updateProductDTO);
            return updatedProduct?.ToProductDto();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepo.DeleteAsync(id);
            return product != null;
        }
    }
}
