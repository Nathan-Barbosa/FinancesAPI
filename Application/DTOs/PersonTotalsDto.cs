namespace FinancesAPI.Application.DTOs
{
    public class PersonTotalsDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }
    }
}
