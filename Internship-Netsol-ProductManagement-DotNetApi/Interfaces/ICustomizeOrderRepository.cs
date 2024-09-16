using Internship_Netsol_ProductManagement_DotNetApi.Migrations;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.Models;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;



namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface ICustomizeOrderRepository
    {
        public Task<CustomizeOrder> CreateCustomizeOrderAsync(CustomizeOrder customizeOrder);
        public Task<CustomizeOrder> GetCustomizeOrderByIdAsync(int id);
        public Task<List<CustomizeOrder>> GetAllAsync(CustomizeOrderQueryObject query);


    }
}
