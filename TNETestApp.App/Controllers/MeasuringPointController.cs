using Microsoft.AspNetCore.Mvc;
using TNETestApp.Domain.Models;
using TNETestApp.Services.Interfaces.Services;
using TNETestApp.Services.MeasuringPoints.Commands;

namespace TNETestApp.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuringPointController : ControllerBase
    {
        private readonly IMeasuringPointService _measuringPointService;
        public MeasuringPointController(IMeasuringPointService measuringPointHandler)
        {
            _measuringPointService = measuringPointHandler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasuringPoint))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MeasuringPoint>> Create([FromBody] CreateMeasuringPointCommand command, CancellationToken cancellationToken)
        {
            var response = await _measuringPointService.Create(command, cancellationToken);
            return Created(new Uri($"api/MeasuringPoint/{response}", UriKind.Relative), response);
        }
    }
}
