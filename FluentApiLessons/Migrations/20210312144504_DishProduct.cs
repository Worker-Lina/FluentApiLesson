using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApiLessons.Migrations
{
    public partial class DishProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_dishes_dishId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_dishId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "dishId",
                table: "products");

            migrationBuilder.CreateTable(
                name: "DishProducts",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishProducts", x => new { x.DishesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DishProducts_dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishProducts_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishProducts_ProductsId",
                table: "DishProducts",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "dishId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_products_dishId",
                table: "products",
                column: "dishId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_dishes_dishId",
                table: "products",
                column: "dishId",
                principalTable: "dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
