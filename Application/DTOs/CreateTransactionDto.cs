using FinancesAPI.Domain.Enums;

namespace FinancesAPI.Application.DTOs
{
    public class CreateTransactionDto
    {
        public string Description { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public TransactionType Type { get; set; }

        public Guid PersonId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
