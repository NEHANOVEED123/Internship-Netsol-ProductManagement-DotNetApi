using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Mappers;
using Internship_Netsol_ProductManagement_DotNetApi.Models;

namespace Internship_Netsol_ProductManagement_DotNetApi.BLL
{
    public class CustomizeOrderServices : ICustomizeOrderServices
    {
        private readonly ICustomizeOrderRepository _customizeOrderRepo;

        public CustomizeOrderServices(ICustomizeOrderRepository customizeOrderRepo)
        {
            _customizeOrderRepo = customizeOrderRepo;
        }
        public async Task<List<CustomizeOrderDTO>> GetAllAsync(CustomizeOrderQueryObject query)
        {
            var customizeOrder = await _customizeOrderRepo.GetAllAsync(query);
            return customizeOrder.Select(p => p.FromModelToDto()).ToList();
        }
        public async Task<CustomizeOrderDTO> GetCustomizeOrderByIdAsync(int id)
        {
            var customizeOrder = await _customizeOrderRepo.GetCustomizeOrderByIdAsync(id);
            return customizeOrder?.FromModelToDto();
        }

        public async Task<CustomizeOrderDTO> CreateCustomizeOrderAsync(CreateCustomizeOrderDTO customizeOrderDto)
        {
            var customizeOrder = customizeOrderDto.FromDtoToModel();
            customizeOrder.Price = CalculatePrice(customizeOrder.FrontendPages);
            var createdCustomizeOrder = await _customizeOrderRepo.CreateCustomizeOrderAsync(customizeOrder);
            return createdCustomizeOrder.FromModelToDto();
        }

        public decimal CalculatePrice(int frontendPages)
        {
            decimal price = (5000 * frontendPages) + 500;
            return price;
        }

        // Placeholder for future implementation
        public Task<CustomizeOrderDTO> GetCustomizeOrders()
        {
            throw new NotImplementedException();
        }
    }
}
