using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("GetDrinkAveragePrice")]
        public IActionResult GetDrinkAveragePrice()
        {
            return Ok(_statisticsService.TDrinkAveragePrice());
        }
        [HttpGet("GetDrinkCount")]
        public IActionResult GetDrinkCount()
        {
            return Ok(_statisticsService.TDrinkCount());
        }
        [HttpGet("GetLastDrinkName")]
        public IActionResult GetLastDrinkName()
        {
            return Ok(_statisticsService.TLastDrinkName());
        }
        [HttpGet("GetMaxPriceDrink")]
        public IActionResult GetMaxPriceDrink()
        {
            return Ok(_statisticsService.TMaxPriceDrink());
        }
    }
}
