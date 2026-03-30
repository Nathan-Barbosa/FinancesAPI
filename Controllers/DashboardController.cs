using FinancesAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dashboardService.GetAsync();
            return Ok(result);
        }
    }
}