namespace FinancesAPI.Application.DTOs
{
    public class CategoryTotalsResponseDto
    {
        public IEnumerable<CategoryTotalsDto> Categories { get; set; } = [];

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }
    }
}
