namespace FinancesAPI.Application.DTOs
{
    public class PersonTotalsResponseDto
    {
        public IEnumerable<PersonTotalsDto> Persons { get; set; } = [];

        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}
