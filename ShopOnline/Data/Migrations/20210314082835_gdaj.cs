using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class gdaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e86ec14-88de-4666-9e93-56772c4bfca7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6060bcba-0c63-49cf-9d71-9653f2ba1913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c80bec67-152b-47f1-b4e6-cd5230328d43");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductLastPrice",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4692be72-4d89-43fd-a139-9c1a4dc943a2", "3bf1949a-aed5-4b33-9e48-0f460bb42eae", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21abd6c8-6173-460c-a24f-6b42499833b4", "dc56b088-a8ee-4615-9ab6-c1d3037d89a0", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1bd9671-2ea2-44af-8669-9777014aa195", "aa54ba8a-678c-4571-8e1b-5182705e11c1", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21abd6c8-6173-460c-a24f-6b42499833b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4692be72-4d89-43fd-a139-9c1a4dc943a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bd9671-2ea2-44af-8669-9777014aa195");

            migrationBuilder.AlterColumn<string>(
                name: "ProductPrice",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ProductLastPrice",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e86ec14-88de-4666-9e93-56772c4bfca7", "3aa1b7eb-898a-42cb-9b45-62710c6eeed7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6060bcba-0c63-49cf-9d71-9653f2ba1913", "ad2adbac-fb07-41ca-bc80-c7ed0d405047", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c80bec67-152b-47f1-b4e6-cd5230328d43", "6d3258c7-4fbf-4c8f-b801-10ca2aaece5d", "Customer", "Customer" });
        }
    }
}
