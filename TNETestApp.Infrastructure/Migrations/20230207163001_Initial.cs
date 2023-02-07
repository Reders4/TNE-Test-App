using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TNETestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subsidiary_companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subsidiary_companies", x => x.id);
                    table.ForeignKey(
                        name: "fk_subsidiary_companies_companies_company_id",
                        column: x => x.companyid,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consumer_buildings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "integer", nullable: false),
                    subsidiarycompanyid = table.Column<int>(name: "subsidiary_company_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consumer_buildings", x => x.id);
                    table.ForeignKey(
                        name: "fk_consumer_buildings_companies_company_id",
                        column: x => x.companyid,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_consumer_buildings_subsidiary_companies_subsidiary_company_",
                        column: x => x.subsidiarycompanyid,
                        principalTable: "subsidiary_companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "delivery_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    maxpower = table.Column<int>(name: "max_power", type: "integer", nullable: false),
                    consumerbuildingid = table.Column<int>(name: "consumer_building_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_delivery_points", x => x.id);
                    table.ForeignKey(
                        name: "fk_delivery_points_consumer_buildings_consumer_building_id",
                        column: x => x.consumerbuildingid,
                        principalTable: "consumer_buildings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "measuring_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    consumerbuildingid = table.Column<int>(name: "consumer_building_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_measuring_points", x => x.id);
                    table.ForeignKey(
                        name: "fk_measuring_points_consumer_buildings_consumer_building_id",
                        column: x => x.consumerbuildingid,
                        principalTable: "consumer_buildings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "current_transformers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    transformatortype = table.Column<int>(name: "transformator_type", type: "integer", nullable: false),
                    verificationdate = table.Column<DateTime>(name: "verification_date", type: "timestamp with time zone", nullable: false),
                    outofverificationdate = table.Column<DateTime>(name: "out_of_verification_date", type: "timestamp with time zone", nullable: false),
                    transformerratio = table.Column<double>(name: "transformer_ratio", type: "double precision", nullable: false),
                    measuringpointid = table.Column<int>(name: "measuring_point_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_transformers", x => x.id);
                    table.ForeignKey(
                        name: "fk_current_transformers_measuring_points_measuring_point_id",
                        column: x => x.measuringpointid,
                        principalTable: "measuring_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "electricity_meters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    metertype = table.Column<int>(name: "meter_type", type: "integer", nullable: false),
                    verificationdate = table.Column<DateTime>(name: "verification_date", type: "timestamp with time zone", nullable: false),
                    outofverificationdate = table.Column<DateTime>(name: "out_of_verification_date", type: "timestamp with time zone", nullable: false),
                    measuringpointid = table.Column<int>(name: "measuring_point_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_electricity_meters", x => x.id);
                    table.ForeignKey(
                        name: "fk_electricity_meters_measuring_points_measuring_point_id",
                        column: x => x.measuringpointid,
                        principalTable: "measuring_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "metering_devices",
                columns: table => new
                {
                    measuringpointid = table.Column<int>(name: "measuring_point_id", type: "integer", nullable: false),
                    deliverypointid = table.Column<int>(name: "delivery_point_id", type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(name: "start_date", type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_metering_devices", x => new { x.measuringpointid, x.deliverypointid });
                    table.ForeignKey(
                        name: "fk_metering_devices_delivery_points_delivery_point_id",
                        column: x => x.deliverypointid,
                        principalTable: "delivery_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_metering_devices_measuring_points_measuring_point_id",
                        column: x => x.measuringpointid,
                        principalTable: "measuring_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voltage_transformers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    transformerratio = table.Column<double>(name: "transformer_ratio", type: "double precision", nullable: false),
                    verificationdate = table.Column<DateTime>(name: "verification_date", type: "timestamp with time zone", nullable: false),
                    outofverificationdate = table.Column<DateTime>(name: "out_of_verification_date", type: "timestamp with time zone", nullable: false),
                    transformertype = table.Column<int>(name: "transformer_type", type: "integer", nullable: false),
                    measuringpointid = table.Column<int>(name: "measuring_point_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_voltage_transformers", x => x.id);
                    table.ForeignKey(
                        name: "fk_voltage_transformers_measuring_points_measuring_point_id",
                        column: x => x.measuringpointid,
                        principalTable: "measuring_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_consumer_buildings_company_id",
                table: "consumer_buildings",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_consumer_buildings_subsidiary_company_id",
                table: "consumer_buildings",
                column: "subsidiary_company_id");

            migrationBuilder.CreateIndex(
                name: "ix_current_transformers_measuring_point_id",
                table: "current_transformers",
                column: "measuring_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_delivery_points_consumer_building_id",
                table: "delivery_points",
                column: "consumer_building_id");

            migrationBuilder.CreateIndex(
                name: "ix_electricity_meters_measuring_point_id",
                table: "electricity_meters",
                column: "measuring_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_measuring_points_consumer_building_id",
                table: "measuring_points",
                column: "consumer_building_id");

            migrationBuilder.CreateIndex(
                name: "ix_metering_devices_delivery_point_id",
                table: "metering_devices",
                column: "delivery_point_id");

            migrationBuilder.CreateIndex(
                name: "ix_subsidiary_companies_company_id",
                table: "subsidiary_companies",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_voltage_transformers_measuring_point_id",
                table: "voltage_transformers",
                column: "measuring_point_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "current_transformers");

            migrationBuilder.DropTable(
                name: "electricity_meters");

            migrationBuilder.DropTable(
                name: "metering_devices");

            migrationBuilder.DropTable(
                name: "voltage_transformers");

            migrationBuilder.DropTable(
                name: "delivery_points");

            migrationBuilder.DropTable(
                name: "measuring_points");

            migrationBuilder.DropTable(
                name: "consumer_buildings");

            migrationBuilder.DropTable(
                name: "subsidiary_companies");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
