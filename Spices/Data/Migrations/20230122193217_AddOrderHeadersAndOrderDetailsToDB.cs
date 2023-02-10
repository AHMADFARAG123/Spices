using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spices.Data.Migrations
{
    public partial class AddOrderHeadersAndOrderDetailsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    iD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseriD = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotalOrginal = table.Column<double>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: false),
                    Couponcode = table.Column<string>(nullable: true),
                    CouponcodeDiscount = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    PickUpName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TrasactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.iD);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_UseriD",
                        column: x => x.UseriD,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderiD = table.Column<int>(nullable: false),
                    MenuIteMid = table.Column<int>(nullable: false),
                    cOunt = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_MenuItems_MenuIteMid",
                        column: x => x.MenuIteMid,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_orderiD",
                        column: x => x.orderiD,
                        principalTable: "OrderHeaders",
                        principalColumn: "iD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuIteMid",
                table: "OrderDetails",
                column: "MenuIteMid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderiD",
                table: "OrderDetails",
                column: "orderiD");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_UseriD",
                table: "OrderHeaders",
                column: "UseriD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeaders");
        }
    }
}
