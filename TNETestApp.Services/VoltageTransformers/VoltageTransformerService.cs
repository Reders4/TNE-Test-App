using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Models;
using TNETestApp.Infrastructure;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.Services.VoltageTransformers
{
    public sealed class VoltageTransformerService : IVoltageTransformerService
    {
        private readonly DataContext _context;
        private readonly ILogger<VoltageTransformerService> _logger;
        public VoltageTransformerService(DataContext context, ILogger<VoltageTransformerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<VoltageTransformer>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Getting Voltage Transformers by consumer building Id: {consumerBuildingId}");

            var voltageTransformers = await _context.VoltageTransformers.AsNoTracking()
                .Where(x => x.MeasuringPoint.ConsumerBuildingId == consumerBuildingId).ToListAsync(cancellationToken);

            if (!isOutOfVerification)
            {
                return voltageTransformers;
                
            }
            else
            {
                _logger.LogDebug("Selected Electricity Meters with out of date verefication");
                return voltageTransformers.Where(x => x.OutOfVerificationDate < DateTime.Now).ToList();
            }
        }
    }
}
