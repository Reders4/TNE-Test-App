using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Models;
using TNETestApp.Infrastructure;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.Services.CurrentTransformers
{
    public sealed class CurrentTransformerService : ICurrentTransformerService
    {
        private readonly DataContext _context;
        private readonly ILogger<CurrentTransformerService> _logger;
        public CurrentTransformerService(DataContext context, ILogger<CurrentTransformerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<CurrentTransformer>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Getting Current Transformes by consumer building Id: {consumerBuildingId}");

            var currentTransformers = await _context.CurrentTransformers.AsNoTracking()
                 .Where(x => x.MeasuringPoint.ConsumerBuildingId == consumerBuildingId).ToListAsync(cancellationToken);
            if (!isOutOfVerification)
            {
                return currentTransformers;
            }
            else
            {
                _logger.LogDebug("Selected Current Transformers with out of date verefication");
                return currentTransformers.Where(x => x.OutOfVerificationDate < DateTime.Now).ToList();
            }
        }
    }
}
