using FinancesAPI.Application.DTOs;
using FinancesAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var response = await _categoryService.CreateAsync(createCategoryDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAsync();
            return Ok(result);
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetTotals()
        {
            var result = await _categoryService.GetTotalsAsync();
            return Ok(result);
        }
    }
}