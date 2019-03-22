using Microsoft.EntityFrameworkCore.Migrations;

namespace AgrotutorAPI.Data.Postgresql.Migrations
{
    public partial class AddnewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceID",
                table: "Plots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountSold",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlotArea",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellingPrice",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "AmountSold",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "PlotArea",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Activities");
        }
    }
}
