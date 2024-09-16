using Microsoft.AspNetCore.Mvc;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using System.Threading.Tasks;

namespace Internship_Netsol_ProductManagement_DotNetApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

    

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }


        [HttpPost("auth")]
        public async Task<IActionResult> UserAuthenticate([FromBody] UserCredentials credentials)
        {
            var isAuthenticated = await _userService.UserAuthenticationAsync(credentials.email, credentials.password);

            if (isAuthenticated)
            {
                return Ok(new { success = true, message = "Login successful" });
            }

            return Unauthorized(new { success = false, message = "Invalid credentials" });
        }

        // Define a simple class to accept the credentials
        public class UserCredentials
        {
            public string email { get; set; }
            public string password { get; set; }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
