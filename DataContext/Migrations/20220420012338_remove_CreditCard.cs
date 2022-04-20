using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class remove_CreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Creditcards",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Creditcards");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Creditcard_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Creditcard_id",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Creditcard_id",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Creditcards",
                columns: table => new
                {
                    Creditcard_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Card_expiredate = table.Column<DateTime>(type: "date", nullable: false),
                    Card_Number = table.Column<int>(type: "int", nullable: false),
                    Card_pin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditcards", x => x.Creditcard_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Creditcard_id",
                table: "Orders",
                column: "Creditcard_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Creditcards",
                table: "Orders",
                column: "Creditcard_id",
                principalTable: "Creditcards",
                principalColumn: "Creditcard_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
