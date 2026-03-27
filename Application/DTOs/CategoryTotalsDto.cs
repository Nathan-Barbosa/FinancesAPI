namespace FinancesAPI.Application.DTOs;

public class CategoryTotalsDto
{
    public string Description { get; set; } = string.Empty;

    public decimal TotalIncome { get; set; }

    public decimal TotalExpense { get; set; }

    public decimal Balance { get; set; }
}