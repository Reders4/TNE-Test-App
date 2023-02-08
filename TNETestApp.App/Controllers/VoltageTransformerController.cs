using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TNETestApp.Domain.Models;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoltageTransformerController : ControllerBase
    {
        private readonly IVoltageTransformerService _voltageTransformerService;
        public VoltageTransformerController(IVoltageTransformerService voltageTransformerService)
        {
            _voltageTransformerService = voltageTransformerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<VoltageTransformer>>> GetList([Required] int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            var response = await _voltageTransformerService.GetList(consumerBuildingId, isOutOfVerification, cancellationToken);
            return Ok(response);
        }
    }
}
