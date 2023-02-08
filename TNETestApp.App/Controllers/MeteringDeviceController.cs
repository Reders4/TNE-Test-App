using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TNETestApp.Domain.Models;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteringDeviceController : ControllerBase
    {
        private readonly IMeteringDeviceService _meteringDeviceService;
        public MeteringDeviceController(IMeteringDeviceService meteringDeviceService)
        {
            _meteringDeviceService = meteringDeviceService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<MeteringDevice>>> GetListByYear([Required] int year, CancellationToken cancellationToken)
        {
            var response = await _meteringDeviceService.GetListByYear(year, cancellationToken);
            return Ok(response);
        }
    }
}
