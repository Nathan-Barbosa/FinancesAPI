using FinancesAPI.Domain.Enums;

namespace FinancesAPI.Application.DTOs;

public class CategoryResponseDto
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public CategoryPurpose Purpose { get; set; }
}