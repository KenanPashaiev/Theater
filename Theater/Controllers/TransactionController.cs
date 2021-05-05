using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Theater.BL.Models.Transaction;
using Theater.BL.Services;

namespace Theater.Controllers
{
    [ApiController]
    [Route("Transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Gets Transaction by id
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionAsync([FromRoute]Guid id)
        {
            var transaction = await transactionService.GetTransactionAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        /// <summary>
        /// Gets all Transactions
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            var transactions = await transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        /// <summary>
        /// Gets all Transactions by id
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetTransactionsByUserIdAsync(Guid userId)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (role.Value == "Client" && (currentUserId == null || currentUserId.Value != userId.ToString()))
            {
                return Unauthorized();
            }

            var transactions = await transactionService.GetTransactionByUserIdAsync(userId);
            return Ok(transactions);
        }

        /// <summary>
        /// Adds Transaction
        /// </summary>
        [Authorize(Roles = "Client, Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTransactionAsync(TransactionCreateDto transactionCreateUpdateDto)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Role");
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "NameIdentifier");
            if (role.Value == "Client" && (currentUserId == null || currentUserId.Value != transactionCreateUpdateDto.UserId.ToString()))
            {
                return Unauthorized();
            }

            var transactions = await transactionService.AddTransactionAsync(transactionCreateUpdateDto);
            return Ok(transactions);
        }
    }
}
