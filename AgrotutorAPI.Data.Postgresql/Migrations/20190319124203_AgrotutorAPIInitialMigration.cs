using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgrotutorAPI.Data.Postgresql.Migrations
{
    public partial class AgrotutorAPIInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActivityType = table.Column<int>(nullable: false),
                    AmountApplied = table.Column<string>(nullable: true),
                    AppliedProduct = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Dose = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfSeeds = table.Column<double>(nullable: false),
                    PlotId = table.Column<int>(nullable: false),
                    ParcelId = table.Column<string>(nullable: true),
                    ProductObtained = table.Column<string>(nullable: true),
                    Sown = table.Column<string>(nullable: true),
                    WeightOfSeeds = table.Column<double>(nullable: false),
                    Yield = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: true),
                    Accuracy = table.Column<double>(nullable: true),
                    Speed = table.Column<double>(nullable: true),
                    Course = table.Column<double>(nullable: true),
                    PlotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClimateType = table.Column<int>(nullable: false),
                    CropType = table.Column<int>(nullable: false),
                    MaturityType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Irrigated = table.Column<bool>(nullable: false),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plots_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PlotId",
                table: "Activities",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItem_PlotId",
                table: "MediaItem",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_PositionId",
                table: "Plots",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PlotId",
                table: "Position",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Plots_PlotId",
                table: "Activities",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItem_Plots_PlotId",
                table: "MediaItem",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Plots_PlotId",
                table: "Position",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Plots_PlotId",
                table: "Position");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "MediaItem");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
