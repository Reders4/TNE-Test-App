using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TNETestApp.Domain.Models;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityMeterController : ControllerBase
    {
        private readonly IElectricityMeterService _electricityMeterService;
        public ElectricityMeterController(IElectricityMeterService electricityMeterService)
        {
            _electricityMeterService = electricityMeterService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<ElectricityMeter>>> GetList([Required] int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            var response = await _electricityMeterService.GetList(consumerBuildingId, isOutOfVerification, cancellationToken);
            return Ok(response);
        }
    }
}
