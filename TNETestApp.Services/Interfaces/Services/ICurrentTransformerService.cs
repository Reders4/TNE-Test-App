using TNETestApp.Domain.Models;

namespace TNETestApp.Services.Interfaces.Services
{
    public interface ICurrentTransformerService
    {
        Task<IReadOnlyCollection<CurrentTransformer>> GetList(int consumerBuildingId, bool isOutOfVerification, CancellationToken cancellationToken);
    }
}
