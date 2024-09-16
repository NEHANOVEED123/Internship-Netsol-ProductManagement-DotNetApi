using Microsoft.AspNetCore.Mvc;
using Internship_Netsol_ProductManagement_DotNetApi.BLL;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.Mappers;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;

namespace Internship_Netsol_ProductManagement_DotNetApi.Controllers
{
    [ApiController]
    [Route("api/CustomizeOrder")]
    public class CustomizeOrderController : ControllerBase
    {
        private readonly ICustomizeOrderServices _customizeOrderService;

        public CustomizeOrderController(ICustomizeOrderServices customizeOrderService)
        {
            _customizeOrderService = customizeOrderService;
        }

       
        [HttpGet("{Id:int}")] // Specifies that this method responds to GET requests with an ID parameter in the URL.
        public async Task<IActionResult> GetCustomizeOrderByIdAsync([FromRoute] int Id) // Method to get a Product by their ID.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customizeOrder = await _customizeOrderService.GetCustomizeOrderByIdAsync(Id); // Finds the Product with the given ID in the database.
            if (customizeOrder == null) // Checks if the Product is not found.
            {
                return NotFound(); // Returns a 404 Not Found response if the Product does not exist.
            }
            return Ok(customizeOrder); // Returns the found Product mapped to a DTO as a 200 OK response.
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomizeOrderDTO customizeOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customizeOrder = await _customizeOrderService.CreateCustomizeOrderAsync(customizeOrderDto);

            // Use nameof(GetCustomizeOrderByIdAsync) and ensure the correct route and parameter for `CreatedAtAction`
            return Ok(customizeOrder);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CustomizeOrderQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customizeOrders = await _customizeOrderService.GetAllAsync(query);
            var customizeOrderDtos = customizeOrders.Select(order => new CustomizeOrderDTO
            {
                Id = order.Id,
                Title = order.Title,
                Description = order.Description,
                PaymentStatus = order.PaymentStatus,
                PaymentType = order.PaymentType,
                FrontendPages = order.FrontendPages,
                Note = order.Note,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
            }).ToList(); // Converting to a list if needed

            return Ok(customizeOrderDtos); // Returns the list of DTOs as a 200 OK response.
        }




    }
}
