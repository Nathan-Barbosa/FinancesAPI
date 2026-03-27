namespace FinancesAPI.Domain.Entities
{
    using FinancesAPI.Domain.Enums;
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; } = string.Empty;

        public CategoryPurpose Purpose { get; set; }

        public List<Transaction> Transactions { get; set; } = new();
    }
}
