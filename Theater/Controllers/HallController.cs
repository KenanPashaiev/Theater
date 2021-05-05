using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Theater.BL.Models.Hall;
using Theater.BL.Services;

namespace Theater.Controllers
{
    [ApiController]
    [Route("Hall")]
    public class HallController : ControllerBase
    {
        private readonly IHallService hallService;

        public HallController(IHallService hallService)
        {
            this.hallService = hallService;
        }

        /// <summary>
        /// Gets Hall by name
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetHall([FromRoute] string name)
        {
            var hall = await hallService.GetHallByNameAsync(name);
            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        /// <summary>
        /// Gets all Halls
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpGet]
        public async Task<IActionResult> GetHalls(bool includeInactive)
        {
            var halls = await hallService.GetAllHallsAsync(includeInactive);
            return Ok(halls);
        }

        /// <summary>
        /// Adds Hall
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddHall(HallCreateDto hallCreateUpdateDto)
        {
            var halls = await hallService.AddHallAsync(hallCreateUpdateDto);
            return Ok(halls);
        }

        /// <summary>
        /// Updates Hall by name
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateHall(string name, HallUpdateDto hallCreateUpdateDto)
        {
            var existingHall = await hallService.GetHallByNameAsync(name);
            if (existingHall == null)
            {
                return NotFound();
            }

            var halls = await hallService.UpdateHallAsync(name, hallCreateUpdateDto);
            return Ok(halls);
        }

        /// <summary>
        /// Deletes Hall by name
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteHall(string name)
        {
            var existingHall = await hallService.GetHallByNameAsync(name);
            if (existingHall == null)
            {
                return NotFound();
            }

            var halls = await hallService.DeleteHallAsync(name);
            return Ok(halls);
        }
    }
}
