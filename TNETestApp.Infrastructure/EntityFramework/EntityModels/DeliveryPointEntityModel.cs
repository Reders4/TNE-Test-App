using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class DeliveryPointEntityModel : IEntityTypeConfiguration<DeliveryPoint>
    {
        public void Configure(EntityTypeBuilder<DeliveryPoint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.MaxPower).IsRequired();
            builder.Property(x => x.ConsumerBuildingId).IsRequired();

            builder.HasOne(x => x.ConsumerBuilding).WithMany(x => x.DeliveryPoints).HasForeignKey(x => x.ConsumerBuildingId);
        }
    }
}
