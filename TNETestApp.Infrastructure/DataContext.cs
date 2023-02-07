using Microsoft.EntityFrameworkCore;
using TNETestApp.Domain.Models;

namespace TNETestApp.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ConsumerBuilding> ConsumerBuildings { get; set; }
        public virtual DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public virtual DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public virtual DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public virtual DbSet<MeasuringPoint> MeasuringPoints { get; set; }
        public virtual DbSet<MeteringDevice> MeteringDevices { get; set; }
        public virtual DbSet<SubsidiaryCompany> SubsidiaryCompanies { get; set; }
        public virtual DbSet<VoltageTransformer> VoltageTransformers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeteringDevice>().HasKey(x => new { x.MeasuringPointId, x.DeliveryPointId });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Company).Assembly);
        }
    }
}
