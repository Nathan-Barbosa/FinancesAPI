using FinancesAPI.Domain.Enums;

namespace FinancesAPI.Application.DTOs;

public class CreateCategoryDto
{
    public string Description { get; set; } = string.Empty;

    public CategoryPurpose Purpose { get; set; }
}