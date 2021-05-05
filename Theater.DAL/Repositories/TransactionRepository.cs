using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext applicationContext;

        public TransactionRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Transaction> GetTransactionAsync(Guid id)
        {
            return await applicationContext.Transactions.
                SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByUserIdAsync(Guid userId)
        {
            return await applicationContext.Transactions.
                Where(t => t.UserId == userId).ToArrayAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await applicationContext.Transactions.ToArrayAsync();
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            var addedTransaction = await applicationContext.Transactions.AddAsync(transaction);
            applicationContext.SaveChanges();
            return await GetTransactionAsync(addedTransaction.Entity.Id);
        }
    }
}
