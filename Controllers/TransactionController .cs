using FinancesAPI.Application.DTOs;
using FinancesAPI.Application.Services;
using FinancesAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto createTransactionDto)
        {
            try
            {
                var transaction = new Transaction
                {
                    Description = createTransactionDto.Description,
                    Value = createTransactionDto.Value,
                    Type = createTransactionDto.Type,
                    PersonId = createTransactionDto.PersonId,
                    CategoryId = createTransactionDto.CategoryId
                };

                var response = await _transactionService.CreateAsync(transaction);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transactions = await _transactionService.GetAllAsync();

            var result = transactions.Select(transaction => new TransactionResponseDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Type = transaction.Type,
                PersonName = transaction.Person.Name,
                CategoryDescription = transaction.Category.Description
            });

            return Ok(result);
        }
    }
}
