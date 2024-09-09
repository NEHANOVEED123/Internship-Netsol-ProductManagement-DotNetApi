using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Internship_Netsol_ProductManagement_DotNetApi.DAL;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Models;
using System.Threading.Tasks;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;

namespace Internship_Netsol_ProductManagement_DotNetApi.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDBContext _context;
        //dependency injection
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;

        }
        public Task<bool> ProductExists(int id)
        {
            return _context.Products.AnyAsync(x => x.Id == id);
        }
        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products
                                            .FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }

            // Remove the associated comments first

            // Then remove the person
            _context.Products.Remove(productModel);

            await _context.SaveChangesAsync();

            return productModel;
        }

        //repository pattern
        public async Task<List<Product>> GetAllAsync(ProductQueryObject query)
        {
            var product = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(query.Name))
            {
                product = product.Where(s => s.Name.Contains(query.Name));
            }
            if (query.Price.HasValue)
            {
                product = product.Where(s => s.Price >= query.Price.Value);
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    product = query.IsDescending ? product.OrderByDescending(s => s.Name) : product.OrderBy(s => s.Name);
                }

            }
            return await product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }



        public async Task<Product?> UpdateAsync(int id, UpdateProductDTO productDTO)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = productDTO.Name;
            existingProduct.Price = productDTO.Price ?? 0.0; // Use a default value of 0.0 if Price is null

            existingProduct.Description = productDTO.Description; // Use the instance 'productDTO'


            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
