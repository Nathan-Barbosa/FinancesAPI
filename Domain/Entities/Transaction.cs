namespace FinancesAPI.Domain.Entities
{
    using FinancesAPI.Domain.Enums;
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public TransactionType Type { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
