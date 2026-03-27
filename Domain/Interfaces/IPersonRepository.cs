using FinancesAPI.Domain.Entities;

namespace FinancesAPI.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAsync();
        Task<Person?> GetByIdAsync(Guid id);
        Task AddAsync(Person person);
        Task DeleteAsync(Person person);
        Task SaveChangesAsync();
        Task<List<Person>> GetWithTransactionsAsync();
    }
}