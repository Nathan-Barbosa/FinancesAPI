using FinancesAPI.Domain.Enums;

namespace FinancesAPI.Application.DTOs
{
    public class TransactionResponseDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public TransactionType Type { get; set; }

        public string PersonName { get; set; } = string.Empty;

        public string CategoryDescription { get; set; } = string.Empty;
    }
}
