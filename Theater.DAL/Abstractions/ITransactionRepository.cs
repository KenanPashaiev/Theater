using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionAsync(Guid id);

        Task<IEnumerable<Transaction>> GetTransactionByUserIdAsync(Guid userId);

        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task<Transaction> AddTransactionAsync(Transaction transaction);
    }
}
