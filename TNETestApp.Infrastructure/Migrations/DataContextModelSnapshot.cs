﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace TNETestApp.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TNETestApp.Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.ConsumerBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("SubsidiaryCompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("subsidiary_company_id");

                    b.HasKey("Id")
                        .HasName("pk_consumer_buildings");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_consumer_buildings_company_id");

                    b.HasIndex("SubsidiaryCompanyId")
                        .HasDatabaseName("ix_consumer_buildings_subsidiary_company_id");

                    b.ToTable("consumer_buildings", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.CurrentTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MeasuringPointId")
                        .HasColumnType("integer")
                        .HasColumnName("measuring_point_id");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<DateTime>("OutOfVerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("out_of_verification_date");

                    b.Property<int>("TransformatorType")
                        .HasColumnType("integer")
                        .HasColumnName("transformator_type");

                    b.Property<double>("TransformerRatio")
                        .HasColumnType("double precision")
                        .HasColumnName("transformer_ratio");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("verification_date");

                    b.HasKey("Id")
                        .HasName("pk_current_transformers");

                    b.HasIndex("MeasuringPointId")
                        .IsUnique()
                        .HasDatabaseName("ix_current_transformers_measuring_point_id");

                    b.ToTable("current_transformers", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.DeliveryPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumerBuildingId")
                        .HasColumnType("integer")
                        .HasColumnName("consumer_building_id");

                    b.Property<int>("MaxPower")
                        .HasColumnType("integer")
                        .HasColumnName("max_power");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_delivery_points");

                    b.HasIndex("ConsumerBuildingId")
                        .HasDatabaseName("ix_delivery_points_consumer_building_id");

                    b.ToTable("delivery_points", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.ElectricityMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MeasuringPointId")
                        .HasColumnType("integer")
                        .HasColumnName("measuring_point_id");

                    b.Property<int>("MeterType")
                        .HasColumnType("integer")
                        .HasColumnName("meter_type");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<DateTime>("OutOfVerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("out_of_verification_date");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("verification_date");

                    b.HasKey("Id")
                        .HasName("pk_electricity_meters");

                    b.HasIndex("MeasuringPointId")
                        .IsUnique()
                        .HasDatabaseName("ix_electricity_meters_measuring_point_id");

                    b.ToTable("electricity_meters", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.MeasuringPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumerBuildingId")
                        .HasColumnType("integer")
                        .HasColumnName("consumer_building_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_measuring_points");

                    b.HasIndex("ConsumerBuildingId")
                        .HasDatabaseName("ix_measuring_points_consumer_building_id");

                    b.ToTable("measuring_points", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.MeteringDevice", b =>
                {
                    b.Property<int>("MeasuringPointId")
                        .HasColumnType("integer")
                        .HasColumnName("measuring_point_id");

                    b.Property<int>("DeliveryPointId")
                        .HasColumnType("integer")
                        .HasColumnName("delivery_point_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("MeasuringPointId", "DeliveryPointId")
                        .HasName("pk_metering_devices");

                    b.HasIndex("DeliveryPointId")
                        .HasDatabaseName("ix_metering_devices_delivery_point_id");

                    b.ToTable("metering_devices", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.SubsidiaryCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_subsidiary_companies");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_subsidiary_companies_company_id");

                    b.ToTable("subsidiary_companies", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.VoltageTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MeasuringPointId")
                        .HasColumnType("integer")
                        .HasColumnName("measuring_point_id");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<DateTime>("OutOfVerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("out_of_verification_date");

                    b.Property<double>("TransformerRatio")
                        .HasColumnType("double precision")
                        .HasColumnName("transformer_ratio");

                    b.Property<int>("TransformerType")
                        .HasColumnType("integer")
                        .HasColumnName("transformer_type");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("verification_date");

                    b.HasKey("Id")
                        .HasName("pk_voltage_transformers");

                    b.HasIndex("MeasuringPointId")
                        .IsUnique()
                        .HasDatabaseName("ix_voltage_transformers_measuring_point_id");

                    b.ToTable("voltage_transformers", (string)null);
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.ConsumerBuilding", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.Company", "Company")
                        .WithMany("ConsumerBuildings")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_consumer_buildings_companies_company_id");

                    b.HasOne("TNETestApp.Domain.Models.SubsidiaryCompany", "SubsidiaryCompany")
                        .WithMany("ConsumerBuildings")
                        .HasForeignKey("SubsidiaryCompanyId")
                        .HasConstraintName("fk_consumer_buildings_subsidiary_companies_subsidiary_company_");

                    b.Navigation("Company");

                    b.Navigation("SubsidiaryCompany");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.CurrentTransformer", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.MeasuringPoint", "MeasuringPoint")
                        .WithOne("CurrentTransformer")
                        .HasForeignKey("TNETestApp.Domain.Models.CurrentTransformer", "MeasuringPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_current_transformers_measuring_points_measuring_point_id");

                    b.Navigation("MeasuringPoint");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.DeliveryPoint", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.ConsumerBuilding", "ConsumerBuilding")
                        .WithMany("DeliveryPoints")
                        .HasForeignKey("ConsumerBuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_delivery_points_consumer_buildings_consumer_building_id");

                    b.Navigation("ConsumerBuilding");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.ElectricityMeter", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.MeasuringPoint", "MeasuringPoint")
                        .WithOne("ElectricityMeter")
                        .HasForeignKey("TNETestApp.Domain.Models.ElectricityMeter", "MeasuringPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_electricity_meters_measuring_points_measuring_point_id");

                    b.Navigation("MeasuringPoint");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.MeasuringPoint", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.ConsumerBuilding", "ConsumerBuilding")
                        .WithMany("MeasuringPoints")
                        .HasForeignKey("ConsumerBuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_measuring_points_consumer_buildings_consumer_building_id");

                    b.Navigation("ConsumerBuilding");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.MeteringDevice", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.DeliveryPoint", "DeliveryPoint")
                        .WithMany("MeteringDevices")
                        .HasForeignKey("DeliveryPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_metering_devices_delivery_points_delivery_point_id");

                    b.HasOne("TNETestApp.Domain.Models.MeasuringPoint", "MeasuringPoint")
                        .WithMany("MeteringDevices")
                        .HasForeignKey("MeasuringPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_metering_devices_measuring_points_measuring_point_id");

                    b.Navigation("DeliveryPoint");

                    b.Navigation("MeasuringPoint");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.SubsidiaryCompany", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.Company", "Company")
                        .WithMany("SubsidiaryCompanys")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_subsidiary_companies_companies_company_id");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.VoltageTransformer", b =>
                {
                    b.HasOne("TNETestApp.Domain.Models.MeasuringPoint", "MeasuringPoint")
                        .WithOne("VoltageTransformer")
                        .HasForeignKey("TNETestApp.Domain.Models.VoltageTransformer", "MeasuringPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_voltage_transformers_measuring_points_measuring_point_id");

                    b.Navigation("MeasuringPoint");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.Company", b =>
                {
                    b.Navigation("ConsumerBuildings");

                    b.Navigation("SubsidiaryCompanys");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.ConsumerBuilding", b =>
                {
                    b.Navigation("DeliveryPoints");

                    b.Navigation("MeasuringPoints");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.DeliveryPoint", b =>
                {
                    b.Navigation("MeteringDevices");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.MeasuringPoint", b =>
                {
                    b.Navigation("CurrentTransformer");

                    b.Navigation("ElectricityMeter");

                    b.Navigation("MeteringDevices");

                    b.Navigation("VoltageTransformer");
                });

            modelBuilder.Entity("TNETestApp.Domain.Models.SubsidiaryCompany", b =>
                {
                    b.Navigation("ConsumerBuildings");
                });
#pragma warning restore 612, 618
        }
    }
}
