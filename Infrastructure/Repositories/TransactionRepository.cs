using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Interfaces;
using FinancesAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
            => await _context.Transactions.AddAsync(transaction);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task<List<Transaction>> GetAllAsync()
            => await _context.Transactions
                .Include(transaction => transaction.Person)
                .Include(transaction => transaction.Category)
                .ToListAsync();
    }
}