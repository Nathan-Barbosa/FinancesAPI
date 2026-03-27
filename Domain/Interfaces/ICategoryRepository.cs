using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAsync();
        Task AddAsync(Category category);
        Task SaveChangesAsync();
        Task<List<Category>> GetWithTransactionsAsync();
        Task<Category?> GetByIdAsync(Guid id);
    }
}