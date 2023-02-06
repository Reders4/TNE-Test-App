using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class MeteringDeviceEntityModel : IEntityTypeConfiguration<MeteringDevice>
    {
        public void Configure(EntityTypeBuilder<MeteringDevice> builder)
        {
            builder.HasKey(x => new { x.MeasuringPointId, x.DeliveryPointId });
            builder.Property(x => x.MeasuringPointId).IsRequired();
            builder.Property(x => x.DeliveryPointId).IsRequired();

            builder.Property(x => x.StartDate).
                HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                )
            .IsRequired();

            builder.Property(x => x.EndDate).
                HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                )
            .IsRequired();

            builder.HasOne(x => x.MeasuringPoint).WithMany(x => x.MeteringDevices).HasForeignKey(x => x.MeasuringPointId);
            builder.HasOne(x => x.DeliveryPoint).WithMany(x => x.MeteringDevices).HasForeignKey(x => x.DeliveryPointId);
        }
    }
}
