using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgrotutorAPI.Data.Postgresql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    CropType = table.Column<int>(nullable: false),
                    Position_Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Position_Latitude = table.Column<double>(nullable: false),
                    Position_Longitude = table.Column<double>(nullable: false),
                    Position_Altitude = table.Column<double>(nullable: true),
                    Position_Accuracy = table.Column<double>(nullable: true),
                    Position_Speed = table.Column<double>(nullable: true),
                    Position_Course = table.Column<double>(nullable: true),
                    ClimateType = table.Column<int>(nullable: false),
                    MaturityType = table.Column<int>(nullable: false),
                    Irrigated = table.Column<bool>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ActivityType = table.Column<int>(nullable: false),
                    AmountApplied = table.Column<string>(nullable: true),
                    AppliedProduct = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Dose = table.Column<double>(nullable: false),
                    NumberOfSeeds = table.Column<double>(nullable: false),
                    PlotId = table.Column<int>(nullable: false),
                    ParcelId = table.Column<string>(nullable: true),
                    ProductObtained = table.Column<string>(nullable: true),
                    Sown = table.Column<string>(nullable: true),
                    WeightOfSeeds = table.Column<double>(nullable: false),
                    Yield = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    SellingPrice = table.Column<int>(nullable: true),
                    PlotArea = table.Column<int>(nullable: true),
                    AmountSold = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delineations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Position_Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Position_Latitude = table.Column<double>(nullable: false),
                    Position_Longitude = table.Column<double>(nullable: false),
                    Position_Altitude = table.Column<double>(nullable: true),
                    Position_Accuracy = table.Column<double>(nullable: true),
                    Position_Speed = table.Column<double>(nullable: true),
                    Position_Course = table.Column<double>(nullable: true),
                    PlotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delineations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delineations_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    PlotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaItem_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PlotId",
                table: "Activities",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Delineations_PlotId",
                table: "Delineations",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItem_PlotId",
                table: "MediaItem",
                column: "PlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Delineations");

            migrationBuilder.DropTable(
                name: "MediaItem");

            migrationBuilder.DropTable(
                name: "Plots");
        }
    }
}
