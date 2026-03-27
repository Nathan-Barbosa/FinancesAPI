using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Interfaces;
using FinancesAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAsync()
            => await _context.Persons.ToListAsync();

        public async Task<Person?> GetByIdAsync(Guid id)
            => await _context.Persons.FindAsync(id);

        public async Task AddAsync(Person person)
            => await _context.Persons.AddAsync(person);

        public async Task DeleteAsync(Person person)
            => _context.Persons.Remove(person);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task<List<Person>> GetWithTransactionsAsync()
            => await _context.Persons
                .Include(person => person.Transactions)
                .ToListAsync();
    }
}