using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Theater.BL.Models.Session;
using Theater.BL.Services;

namespace Theater.Controllers
{
    [ApiController]
    [Route("Session")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        /// <summary>
        /// Gets Session by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSession([FromRoute]Guid id)
        {
            var session = await sessionService.GetSessionAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        /// <summary>
        /// Gets all Sessions
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSessions(bool includeInactive)
        {
            var sessions = await sessionService.GetAllSessionsAsync(includeInactive);
            return Ok(sessions);
        }

        /// <summary>
        /// Adds Session
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSession(SessionCreateUpdateDto sessionCreateUpdateDto)
        {
            var sessions = await sessionService.AddSessionAsync(sessionCreateUpdateDto);
            return Ok(sessions);
        }

        /// <summary>
        /// Updates Session by id
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(Guid id, SessionCreateUpdateDto sessionCreateUpdateDto)
        {
            var existingSession = await sessionService.GetSessionAsync(id);
            if (existingSession == null)
            {
                return NotFound();
            }

            var sessions = await sessionService.UpdateSessionAsync(id, sessionCreateUpdateDto);
            return Ok(sessions);
        }

        /// <summary>
        /// Deletes Session by id
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            var existingSession = await sessionService.GetSessionAsync(id);
            if (existingSession == null)
            {
                return NotFound();
            }

            var sessions = await sessionService.DeleteSessionAsync(id);
            return Ok(sessions);
        }
    }
}
