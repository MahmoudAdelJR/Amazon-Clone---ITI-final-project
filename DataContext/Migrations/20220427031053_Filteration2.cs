using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class Filteration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "Filter",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filter_slug",
                table: "Filter",
                column: "slug",
                unique: true,
                filter: "[slug] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Filter_slug",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "Filter");
        }
    }
}
