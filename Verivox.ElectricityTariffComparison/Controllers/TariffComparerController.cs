using Microsoft.AspNetCore.Mvc;
using Verivox.ElectricityTariffComparison.DTOs;
using Verivox.ElectricityTariffComparison.Services;

namespace Verivox.ElectricityTariffComparison.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffComparerController : ControllerBase
    {
        private readonly ITarrifCalculator _calculator;
        public TariffComparerController(ITarrifCalculator calculator)
        {
            _calculator = calculator;
        }
       

        [HttpGet(Name = "GetTariffs")]
        public ActionResult<IEnumerable<TarrifCalculationResult>> GetTariffs([FromQuery] decimal consumption)
        {
            try
            {
                return Ok(_calculator.Calculate(consumption));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}