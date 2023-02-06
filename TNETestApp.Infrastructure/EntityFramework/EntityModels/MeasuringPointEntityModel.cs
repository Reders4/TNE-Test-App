using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class MeasuringPointEntityModel : IEntityTypeConfiguration<MeasuringPoint>
    {
        public void Configure(EntityTypeBuilder<MeasuringPoint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.ConsumerBuildingId).IsRequired();

            builder.HasOne(x => x.ConsumerBuilding).WithMany(x => x.MeasuringPoints).HasForeignKey(x => x.ConsumerBuildingId);
            builder.HasOne(x => x.ElectricityMeter).WithOne(x => x.MeasuringPoint).HasForeignKey<ElectricityMeter>(x => x.MeasuringPointId);
            builder.HasOne(x => x.CurrentTransformer).WithOne(x => x.MeasuringPoint).HasForeignKey<CurrentTransformer>(x => x.MeasuringPointId);
            builder.HasOne(x => x.VoltageTransformer).WithOne(x => x.MeasuringPoint).HasForeignKey<VoltageTransformer>(x => x.MeasuringPointId);
        }
    }
}
