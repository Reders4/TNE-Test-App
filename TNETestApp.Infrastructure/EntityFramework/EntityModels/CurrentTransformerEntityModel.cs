using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class CurrentTransformerEntityModel : IEntityTypeConfiguration<CurrentTransformer>
    {
        public void Configure(EntityTypeBuilder<CurrentTransformer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.TransformatorType).IsRequired();
            builder.Property(x => x.VerificationDate).
                HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                )
            .IsRequired();

            builder.Property(x => x.OutOfVerificationDate).
                HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                )
            .IsRequired();
            builder.Property(x => x.TransformerRatio).IsRequired();
            builder.Property(x => x.MeasuringPointId).IsRequired();

        }
    }
}
