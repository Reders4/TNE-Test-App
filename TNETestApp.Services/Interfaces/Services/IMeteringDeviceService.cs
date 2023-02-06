using TNETestApp.Domain.Models;

namespace TNETestApp.Services.Interfaces.Services
{
    public interface IMeteringDeviceService
    {
        Task<IReadOnlyCollection<MeteringDevice>> GetListByYear(int year, CancellationToken cancellationToken);
    }
}
