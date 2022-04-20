using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class linkCustomerProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profileId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_profileId",
                table: "Customer",
                column: "profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_profileId",
                table: "Customer",
                column: "profileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_profileId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_profileId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "profileId",
                table: "Customer");
        }
    }
}
