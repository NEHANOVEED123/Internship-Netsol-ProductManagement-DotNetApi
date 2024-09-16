using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;
using Internship_Netsol_ProductManagement_DotNetApi.Migrations;
using Internship_Netsol_ProductManagement_DotNetApi.Models;


namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface ICustomizeOrderServices
    {
        public Task<CustomizeOrderDTO> CreateCustomizeOrderAsync(CreateCustomizeOrderDTO customizeOrderDto);
        public Task<CustomizeOrderDTO> GetCustomizeOrderByIdAsync(int id);
        public  Task<List<CustomizeOrderDTO>> GetAllAsync(CustomizeOrderQueryObject query);

    }
}
