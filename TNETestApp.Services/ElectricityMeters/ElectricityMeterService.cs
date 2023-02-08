using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Models;
using TNETestApp.Infrastructure;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.Services.ElectricityMeters
{
    public sealed class ElectricityMeterService : IElectricityMeterService
    {
        private readonly DataContext _context;
        private readonly ILogger<ElectricityMeterService> _logger;
        public ElectricityMeterService(DataContext context, ILogger<ElectricityMeterService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IReadOnlyCollection<ElectricityMeter>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Getting Electricity Meters by consumer building Id: {consumerBuildingId}");

            var electricityMeters = await _context.ElectricityMeters.AsNoTracking()
                .Where(x => x.MeasuringPoint.ConsumerBuildingId == consumerBuildingId).ToListAsync(cancellationToken);

            if (!isOutOfVerification)
            {
                return electricityMeters;
                
            }
            else
            {
                _logger.LogDebug("Selected Electricity Meters with out of date verefication");
                return electricityMeters.Where(x => x.OutOfVerificationDate < DateTime.Now).ToList();
            }
        }
    }
}
