using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.OrderServiceAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coupon_code = table.Column<string>(type: "varchar(25)", nullable: true),
                    purchase_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    discount_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    total_itens = table.Column<int>(type: "int", nullable: false),
                    payment_status = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(14)", nullable: false),
                    e_mail = table.Column<string>(type: "varchar(100)", nullable: false),
                    card_number = table.Column<string>(type: "char(16)", nullable: false),
                    cvv = table.Column<string>(type: "char(3)", nullable: false),
                    expiry_month_year = table.Column<string>(type: "char(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    order_header_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailMapping_OrderHeader_order_header_id",
                        column: x => x.order_header_id,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailMapping_order_header_id",
                table: "OrderDetailMapping",
                column: "order_header_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailMapping");

            migrationBuilder.DropTable(
                name: "OrderHeader");
        }
    }
}
