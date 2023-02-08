using TNETestApp.Domain.Models;

namespace TNETestApp.Services.Interfaces.Services
{
    public interface IVoltageTransformerService
    {
        Task<IReadOnlyCollection<VoltageTransformer>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken);
    }
}
