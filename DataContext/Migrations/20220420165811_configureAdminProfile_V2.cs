using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class configureAdminProfile_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_adminProfileId",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "adminProfileId",
                table: "Admin",
                newName: "profileID");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_adminProfileId",
                table: "Admin",
                newName: "IX_Admin_profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_profileID",
                table: "Admin",
                column: "profileID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_profileID",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "profileID",
                table: "Admin",
                newName: "adminProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_profileID",
                table: "Admin",
                newName: "IX_Admin_adminProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_adminProfileId",
                table: "Admin",
                column: "adminProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
