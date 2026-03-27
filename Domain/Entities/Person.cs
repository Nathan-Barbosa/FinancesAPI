namespace FinancesAPI.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public List<Transaction> Transactions { get; set; } = new();

    }
}
