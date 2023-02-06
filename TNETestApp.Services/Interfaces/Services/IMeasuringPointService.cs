using TNETestApp.Domain.Models;
using TNETestApp.Services.MeasuringPoints.Commands;

namespace TNETestApp.Services.Interfaces.Services
{
    public interface IMeasuringPointService
    {
        Task<MeasuringPoint> Create(CreateMeasuringPointCommand command, CancellationToken cancellationToken);
    }
}
