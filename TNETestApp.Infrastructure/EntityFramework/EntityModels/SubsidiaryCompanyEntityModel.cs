using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class SubsidiaryCompanyEntityModel : IEntityTypeConfiguration<SubsidiaryCompany>
    {
        public void Configure(EntityTypeBuilder<SubsidiaryCompany> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.Address).IsUnicode().IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.HasOne(x => x.Company).WithMany(x => x.SubsidiaryCompanys).HasForeignKey(x => x.CompanyId);
        }
    }
}
