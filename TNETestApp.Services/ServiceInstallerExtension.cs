using Microsoft.Extensions.DependencyInjection;
using TNETestApp.Services.CurrentTransformers;
using TNETestApp.Services.ElectricityMeters;
using TNETestApp.Services.Interfaces.Services;
using TNETestApp.Services.MeasuringPoints;
using TNETestApp.Services.MeteringDevices;
using TNETestApp.Services.VoltageTransformers;

namespace TNETestApp.Services
{
    public static class ServiceInstallerExtension
    {
        public static IServiceCollection AddTNETestAppServices(this IServiceCollection services)
        {
            services.AddScoped<IMeasuringPointService, MeasuringPointService>();
            services.AddScoped<IMeteringDeviceService, MeteringDeviceService>();
            services.AddScoped<IElectricityMeterService, ElectricityMeterService>();
            services.AddScoped<ICurrentTransformerService, CurrentTransformerService>();
            services.AddScoped<IVoltageTransformerService, VoltageTransformerService>();

            return services;
        }
    }
}
