using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class linkCustomerProfile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_profileId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "profileId",
                table: "Customer",
                newName: "profileID");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_profileId",
                table: "Customer",
                newName: "IX_Customer_profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_profileID",
                table: "Customer",
                column: "profileID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_profileID",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "profileID",
                table: "Customer",
                newName: "profileId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_profileID",
                table: "Customer",
                newName: "IX_Customer_profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_profileId",
                table: "Customer",
                column: "profileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
