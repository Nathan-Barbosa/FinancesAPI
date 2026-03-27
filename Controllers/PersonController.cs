using FinancesAPI.Application.DTOs;
using FinancesAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonDto createPersonDto)
        {
            try
            {
                var response = await _personService.CreateAsync(createPersonDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePersonDto updatePersonDto)
        {
            try
            {
                var result = await _personService.UpdateAsync(id, updatePersonDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _personService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetTotals()
        {
            var result = await _personService.GetTotalsAsync();
            return Ok(result);
        }
    }
}