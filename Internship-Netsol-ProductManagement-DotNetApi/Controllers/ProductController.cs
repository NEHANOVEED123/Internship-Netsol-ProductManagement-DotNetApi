using Microsoft.AspNetCore.Mvc; // Imports the ASP.NET Core MVC functionalities required to create controllers.
using Internship_Netsol_ProductManagement_DotNetApi.DAL; // Imports the data access layer, specifically the ApplicationDBContext class.
using Internship_Netsol_ProductManagement_DotNetApi.DTO; // Imports the DTO classes for person-related data.
using Internship_Netsol_ProductManagement_DotNetApi.Mappers; // Imports the mapping methods for converting between models and DTOs.
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.FilterQuery;




namespace Internship_Netsol_ProductManagement_DotNetApi.Controllers // Defines the namespace for the controller class, which is essential for organizing code.
{
    [ApiController] // Specifies that this class is an API controller, which means it can handle HTTP requests.
    [Route("api/product")] // Sets the base route for all actions within this controller, meaning all endpoints will start with "api/product".


    public class ProductController : ControllerBase // Inherits from ControllerBase, providing basic functionalities like returning responses.
    {
        private readonly ApplicationDBContext _context; // Declares a private read-only variable to hold the database context instance.
        private readonly IProductRepository _productRepo;


        public ProductController(ApplicationDBContext context, IProductRepository productRepo) // Constructor that receives the database context via dependency injection.
        {
            _productRepo = productRepo;
            _context = context; // Assigns the injected context to the private variable for use within the class.
        }



        [HttpGet] // Specifies that this method responds to HTTP GET requests.
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryObject query) // Method to get all persons from the database.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _productRepo.GetAllAsync(query);
            var productDto = products.Select(s => s.ToProductDto()); // Retrieves all persons, converts them to a list, and maps them to DTOs.
            return Ok(productDto); // Returns the list of persons as a 200 OK response.
        }



        [HttpGet("{Id:int}")] // Specifies that this method responds to GET requests with an ID parameter in the URL.
        public async Task<IActionResult> GetById([FromRoute] int Id) // Method to get a Product by their ID.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepo.GetByIdAsync(Id); // Finds the Product with the given ID in the database.
            if (product == null) // Checks if the Product is not found.
            {
                return NotFound(); // Returns a 404 Not Found response if the Product does not exist.
            }
            return Ok(product.ToProductDto()); // Returns the found Product mapped to a DTO as a 200 OK response.
        }



        [HttpPost] // Specifies that this method responds to HTTP POST requests.
        public async Task<IActionResult> Create([FromBody] CreateProductDTO productDto) // Method to create a new person.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productModel = productDto.ToProductFromCreateDto(); // Maps the incoming DTO to a Person model.
            await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto()); // Returns a 201 Created response, including the new person's data.
        }



        [HttpPut("{id:int}")] // Specifies that this method responds to HTTP PUT requests with an ID parameter in the URL.
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDTO updateDto) // Method to update an existing person.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productModel = await _productRepo.UpdateAsync(id, updateDto); // Finds the person by ID.
            if (productModel == null) // Checks if the person is not found.
            {
                return NotFound(); // Returns a 404 Not Found response if the person does not exist.
            }
            return Ok(productModel.ToProductDto()); // Returns the updated person mapped to a DTO as a 200 OK response.
        }



        [HttpDelete("{id:int}")] // Specifies that this method responds to HTTP DELETE requests with an ID parameter in the URL.
        public async Task<IActionResult> Delete([FromRoute] int id) // Method to delete an existing person.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productModel = await _productRepo.DeleteAsync(id);
            if (productModel == null) // Checks if the person is not found.
            {
                return NotFound(); // Returns a 404 Not Found response if the person does not exist.
            }

            return NoContent(); // Returns a 204 No Content response, indicating successful deletion.
        }


    }
}
