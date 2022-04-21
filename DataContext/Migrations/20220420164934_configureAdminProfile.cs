using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class configureAdminProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adminProfileId",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_adminProfileId",
                table: "Admin",
                column: "adminProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_adminProfileId",
                table: "Admin",
                column: "adminProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_adminProfileId",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_adminProfileId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "adminProfileId",
                table: "Admin");
        }
    }
}
