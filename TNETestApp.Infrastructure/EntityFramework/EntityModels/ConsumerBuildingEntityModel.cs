using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class ConsumerBuildingEntityModel : IEntityTypeConfiguration<ConsumerBuilding>
    {
        public void Configure(EntityTypeBuilder<ConsumerBuilding> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.Address).IsUnicode().IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.SubsidiaryCompanyId);

            builder.HasOne(x => x.Company).WithMany(x => x.ConsumerBuildings).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.SubsidiaryCompany).WithMany(x => x.ConsumerBuildings).HasForeignKey(x => x.SubsidiaryCompanyId);
        }
    }
}
