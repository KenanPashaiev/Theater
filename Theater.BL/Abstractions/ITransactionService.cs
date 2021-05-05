using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Transaction;

namespace Theater.BL.Services
{
    public interface ITransactionService
    {
        Task<TransactionDto> GetTransactionAsync(Guid id);

        Task<IEnumerable<TransactionDto>> GetTransactionByUserIdAsync(Guid userId);

        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();

        Task<TransactionDto> AddTransactionAsync(TransactionCreateDto transactionDtoToAdd);
    }
}
