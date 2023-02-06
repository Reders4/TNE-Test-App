using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Models;
using TNETestApp.Infrastructure;
using TNETestApp.Services.Interfaces.Services;

namespace TNETestApp.Services.MeteringDevices
{
    public sealed class MeteringDeviceService : IMeteringDeviceService
    {
        private readonly DataContext _context;
        private readonly ILogger<MeteringDeviceService> _logger;
        public MeteringDeviceService(DataContext context, ILogger<MeteringDeviceService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IReadOnlyCollection<MeteringDevice>> GetListByYear(int year, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Get Metering Devices by Year:{year}");
            return await _context.MeteringDevices.AsNoTracking()
                .Where(x => x.StartDate.Year <= year && x.EndDate.Year >= year).ToListAsync(cancellationToken);
        }
    }
}
