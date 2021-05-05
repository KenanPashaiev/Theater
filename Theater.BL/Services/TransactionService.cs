using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Transaction;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.BL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }

        public async Task<TransactionDto> GetTransactionAsync(Guid id)
        {
            var transaction = await transactionRepository.GetTransactionAsync(id);
            return mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionByUserIdAsync(Guid userId)
        {
            var transactions = await transactionRepository.GetTransactionByUserIdAsync(userId);
            return mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionDto> AddTransactionAsync(TransactionCreateDto transactionDtoToAdd)
        {
            var transactionToAdd = mapper.Map<Transaction>(transactionDtoToAdd);
            var addedTransaction = await transactionRepository.AddTransactionAsync(transactionToAdd);
            return mapper.Map<TransactionDto>(addedTransaction);
        }
    }
}
