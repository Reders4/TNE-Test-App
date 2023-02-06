using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure.EntityFramework.EntityModels
{
    public class CompanyEntityModel : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.Address).IsUnicode().IsRequired();
        }
    }
}
