using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Models;
using Internship_Netsol_ProductManagement_DotNetApi.DAL;
using Microsoft.EntityFrameworkCore;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;

namespace Internship_Netsol_ProductManagement_DotNetApi.Repository
{
    public class CustomizeOrderRepository : ICustomizeOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomizeOrderRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomizeOrder> CreateCustomizeOrderAsync(CustomizeOrder customizeOrder)
        {
            await _dbContext.CustomizeOrders.AddAsync(customizeOrder);
            await _dbContext.SaveChangesAsync();
            return customizeOrder;
        }

        public async Task<CustomizeOrder> GetCustomizeOrderByIdAsync(int id)
        {
            return await _dbContext.CustomizeOrders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<CustomizeOrder>> GetAllAsync(CustomizeOrderQueryObject query)
        {
            var customizeOrder = _dbContext.CustomizeOrders.AsQueryable();
            if (!string.IsNullOrEmpty(query.Title))
            {
                customizeOrder = customizeOrder.Where(s => s.Title.Contains(query.Title));
            }
            if (query.Price.HasValue)
            {
                customizeOrder = customizeOrder.Where(s => s.Price >= query.Price.Value);
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    customizeOrder = query.IsDescending ? customizeOrder.OrderByDescending(s => s.Title) : customizeOrder.OrderBy(s => s.Title);
                }

            }
            return await customizeOrder.ToListAsync();
        }
    }
}
