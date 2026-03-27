using FinancesAPI.Application.DTOs;
using FinancesAPI.Domain.Entities;
using FinancesAPI.Domain.Enums;
using FinancesAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Application.Services
{
    public class TransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionResponseDto> CreateAsync(Transaction transaction)
        {
            var person = await _context.Persons.FindAsync(transaction.PersonId);
            var category = await _context.Categories.FindAsync(transaction.CategoryId);

            if (person == null)
                throw new Exception("Pessoa não encontrada.");

            if (category == null)
                throw new Exception("Categoria não encontrada.");

            //Valor deve ser positivo
            if (transaction.Value <= 0)
                throw new Exception("O valor deve ser maior que zero.");

            // Menores de idade não podem ter receita
            if (person.Age < 18 && transaction.Type == TransactionType.Income)
                throw new Exception("Menor de idade não pode ter receita.");

            // Validação de categoria
            if (category.Purpose == CategoryPurpose.Expense && transaction.Type == TransactionType.Income)
                throw new Exception("Categoria não permite receita.");

            if (category.Purpose == CategoryPurpose.Income && transaction.Type == TransactionType.Expense)
                throw new Exception("Categoria não permite despesa.");

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Retorno do DTO Montado
            return new TransactionResponseDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Type = transaction.Type,
                PersonName = person.Name,
                CategoryDescription = category.Description
            };
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .Include(transaction => transaction.Person)
                .Include(transaction => transaction.Category)
                .ToListAsync();
        }
    }
}
