using FinancesAPI.Application.DTOs;
using FinancesAPI.Domain.Enums;
using FinancesAPI.Domain.Interfaces;

namespace FinancesAPI.Application.Services
{
    public class DashboardService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DashboardService(IPersonRepository personRepository, ICategoryRepository categoryRepository)
        {
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<DashboardDto> GetAsync()
        {
            var persons = await _personRepository.GetWithTransactionsAsync();
            var categories = await _categoryRepository.GetWithTransactionsAsync();

            var totalPersons = persons.Count;
            var totalCategories = categories.Count;

            var allTransactions = persons
                .SelectMany(person => person.Transactions)
                .ToList();

            var totalTransactions = allTransactions.Count;

            var totalIncome = allTransactions
                .Where(transaction => transaction.Type == TransactionType.Income)
                .Sum(transaction => transaction.Value);

            var totalExpense = allTransactions
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .Sum(transaction => transaction.Value);

            return new DashboardDto
            {
                TotalPersons = totalPersons,
                TotalCategories = totalCategories,
                TotalTransactions = totalTransactions,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense
            };
        }
}
        
     }
    
