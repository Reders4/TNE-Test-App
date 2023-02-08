using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TNETestApp.Domain.Models;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentTransformerController : ControllerBase
    {
        private readonly ICurrentTransformerService _currentTransformerService;
        public CurrentTransformerController(ICurrentTransformerService currentTransformerService)
        {
            _currentTransformerService = currentTransformerService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<CurrentTransformer>>> GetList([Required] int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            var response = await _currentTransformerService.GetList(consumerBuildingId, isOutOfVerification, cancellationToken);
            return Ok(response);
        }
    }
}
