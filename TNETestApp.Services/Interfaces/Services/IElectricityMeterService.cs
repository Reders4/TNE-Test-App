using TNETestApp.Domain.Models;

namespace TNETestApp.Services.Interfaces.Services
{
    public interface IElectricityMeterService
    {
        Task<IReadOnlyCollection<ElectricityMeter>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken);
    }
}
