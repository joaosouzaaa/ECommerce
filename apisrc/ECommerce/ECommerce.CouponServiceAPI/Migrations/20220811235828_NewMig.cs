using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.CouponServiceAPI.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coupon_code = table.Column<string>(type: "char(20)", nullable: false),
                    discount_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "coupon_code", "create_date", "discount_amount", "update_date" },
                values: new object[,]
                {
                    { 1, "Coupon_disc_10", new DateTime(2022, 8, 11, 20, 58, 28, 141, DateTimeKind.Local).AddTicks(8754), 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Coupon_disc_15", new DateTime(2022, 8, 11, 20, 58, 28, 141, DateTimeKind.Local).AddTicks(8764), 15m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Coupon_disc_20", new DateTime(2022, 8, 11, 20, 58, 28, 141, DateTimeKind.Local).AddTicks(8765), 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Coupon_disc_30", new DateTime(2022, 8, 11, 20, 58, 28, 141, DateTimeKind.Local).AddTicks(8766), 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Coupon_disc_50", new DateTime(2022, 8, 11, 20, 58, 28, 141, DateTimeKind.Local).AddTicks(8767), 50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_coupon_code",
                table: "Coupon",
                column: "coupon_code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupon");
        }
    }
}
