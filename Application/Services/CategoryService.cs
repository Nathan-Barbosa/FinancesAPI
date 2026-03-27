using FinancesAPI.Application.DTOs;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Enums;
using FinancesAPI.Domain.Interfaces;

namespace FinancesAPI.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDto.Description))
                throw new Exception("Descrição é obrigatória.");

            if (createCategoryDto.Description.Length > 400)
                throw new Exception("Descrição deve ter no máximo 400 caracteres.");

            var category = new Category
            {
                Description = createCategoryDto.Description,
                Purpose = createCategoryDto.Purpose
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            var response = new CategoryResponseDto
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose
            };

            return response;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAsync()
        {
            var categories = await _categoryRepository.GetAsync();

            var result = categories.Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose
            });

            return result;
        }

        public async Task<object> GetTotalsAsync()
        {
            var categories = await _categoryRepository.GetWithTransactionsAsync();

            var result = categories.Select(category =>
            {
                var totalIncome = category.Transactions
                    .Where(transaction => transaction.Type == TransactionType.Income)
                    .Sum(transaction => transaction.Value);

                var totalExpense = category.Transactions
                    .Where(transaction => transaction.Type == TransactionType.Expense)
                    .Sum(transaction => transaction.Value);

                return new CategoryTotalsDto
                {
                    Description = category.Description,
                    TotalIncome = totalIncome,
                    TotalExpense = totalExpense,
                    Balance = totalIncome - totalExpense
                };
            });

            var totalIncome = result.Sum(result => result.TotalIncome);
            var totalExpense = result.Sum(result => result.TotalExpense);

            var summary = new
            {
                Categories = result,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense
            };

            return summary;
        }
    }
}