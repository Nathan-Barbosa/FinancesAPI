using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task SaveChangesAsync();
        Task<List<Transaction>> GetAllAsync();
    }
}