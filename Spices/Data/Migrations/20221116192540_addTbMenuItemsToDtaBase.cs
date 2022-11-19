using Microsoft.EntityFrameworkCore.Migrations;

namespace Spices.Data.Migrations
{
    public partial class addTbMenuItemsToDtaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_categoryId",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "SubCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_categoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    Spicnyness = table.Column<string>(nullable: true),
                    CATEgoryid = table.Column<int>(nullable: false),
                    SubCategOryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuItems_Categories_CATEgoryid",
                        column: x => x.CATEgoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MenuItems_SubCategories_SubCategOryid",
                        column: x => x.SubCategOryid,
                        principalTable: "SubCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CATEgoryid",
                table: "MenuItems",
                column: "CATEgoryid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_SubCategOryid",
                table: "MenuItems",
                column: "SubCategOryid");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SubCategories",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_categoryId",
                table: "SubCategories",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
