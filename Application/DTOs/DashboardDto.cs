namespace FinancesAPI.Application.DTOs
{
    public class DashboardDto
    {
        public int TotalPersons { get; set; }
        public int TotalCategories { get; set; }
        public int TotalTransactions { get; set; }

        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}