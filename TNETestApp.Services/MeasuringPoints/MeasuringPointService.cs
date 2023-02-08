using Microsoft.Extensions.Logging;
using TNETestApp.Domain.Models;
using TNETestApp.Infrastructure;
using TNETestApp.Services.Interfaces.Services;
using TNETestApp.Services.MeasuringPoints.Commands;

namespace TNETestApp.Services.MeasuringPoints
{
    public sealed class MeasuringPointService : IMeasuringPointService
    {
        private readonly DataContext _context;
        private readonly ILogger<MeasuringPointService> _logger;
        public MeasuringPointService(DataContext context, ILogger<MeasuringPointService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MeasuringPoint> Create(CreateMeasuringPointCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Creating new Measuring Point. Name:{command.Name}, ConsumerBuildingId: {command.CurrentTransformerId}");

            var measuringPoint = new MeasuringPoint()
            {
                Name = command.Name,
                ConsumerBuildingId = command.ConsumerBuildingId,
                ElectricityMeter = await _context.ElectricityMeters.FindAsync(new object[] { command.ElectricityMeterId }, cancellationToken),
                CurrentTransformer = await _context.CurrentTransformers.FindAsync(new object[] { command.CurrentTransformerId }, cancellationToken),
                VoltageTransformer = await _context.VoltageTransformers.FindAsync(new object[] { command.VoltageTransformerId }, cancellationToken)
            };
            _context.MeasuringPoints.Add(measuringPoint);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug($"Measuring Point was saved in database with Id:{measuringPoint.Id}");
            return measuringPoint;
        }
    }
}
