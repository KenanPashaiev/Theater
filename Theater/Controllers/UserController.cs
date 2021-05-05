using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Theater.BL.Models.User;
using Theater.BL.Services;

namespace Theater.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Gets User by id
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync([FromRoute]Guid id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Role");
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "NameIdentifier");
            if (role.Value == "Client" && (currentUserId == null || currentUserId.Value != id.ToString()))
            {
                return Unauthorized();
            }

            var user = await userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        /// <summary>
        /// Gets all Users
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Adds User
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var users = await userService.RegisterAsync(userRegisterDto);
            return Ok(users);
        }

        /// <summary>
        /// Adds User
        /// </summary>
        [HttpGet("Login")]
        public async Task<IActionResult> LoginAsync([FromQuery]UserLoginDto userLoginDto)
        {
            var users = await userService.LoginAsync(userLoginDto);
            if(users == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                users,
                userLoginDto.Email
            });
        }

        /// <summary>
        /// Updates User by id
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "NameIdentifier");
            if (currentUserId == null || currentUserId.Value != id.ToString())
            {
                return Unauthorized();
            }

            var existingUser = await userService.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var users = await userService.UpdateUserAsync(id, userUpdateDto);
            return Ok(users);
        }
    }
}
