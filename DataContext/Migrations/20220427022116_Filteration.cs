using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class Filteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_options");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    display_text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url_slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    display_text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    filter_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterOptions_Filter_filter_id",
                        column: x => x.filter_id,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filters_Categories",
                columns: table => new
                {
                    filter_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters_Categories", x => new { x.category_id, x.filter_id });
                    table.ForeignKey(
                        name: "FK_Filters_Categories_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filters_Categories_Filter_filter_id",
                        column: x => x.filter_id,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filter_Options_Products",
                columns: table => new
                {
                    filter_option_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter_Options_Products", x => new { x.filter_option_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_Filter_Options_Products_FilterOptions_filter_option_id",
                        column: x => x.filter_option_id,
                        principalTable: "FilterOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filter_Options_Products_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_Options_Products_product_id",
                table: "Filter_Options_Products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_FilterOptions_filter_id",
                table: "FilterOptions",
                column: "filter_id");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Categories_filter_id",
                table: "Filters_Categories",
                column: "filter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter_Options_Products");

            migrationBuilder.DropTable(
                name: "Filters_Categories");

            migrationBuilder.DropTable(
                name: "FilterOptions");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    option_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_options",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    option_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_options", x => new { x.product_id, x.option_id });
                    table.ForeignKey(
                        name: "FK_product_options_options",
                        column: x => x.option_id,
                        principalTable: "options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_options_Product",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_options_option_id",
                table: "product_options",
                column: "option_id");
        }
    }
}
