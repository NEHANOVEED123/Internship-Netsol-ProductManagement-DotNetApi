using Microsoft.EntityFrameworkCore;
using Internship_Netsol_ProductManagement_DotNetApi.DAL;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Models;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;

namespace Internship_Netsol_ProductManagement_DotNetApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(x => x.Id == id);
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync(ProductQueryObject query)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
            {
                products = products.Where(s => s.Name.Contains(query.Name));
            }

            if (query.Price.HasValue)
            {
                products = products.Where(s => s.Price >= query.Price.Value);
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                products = query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)
                    ? (query.IsDescending ? products.OrderByDescending(s => s.Name) : products.OrderBy(s => s.Name))
                    : products;
            }

            return await products.ToListAsync();
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
            existingProduct.Price = productDTO.Price ?? 0.0;
            existingProduct.Description = productDTO.Description;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
