using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class tg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PaymenId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5293289c-22de-42c9-b718-f7be427035e9", "f5df2ff7-c14f-4e89-835f-66abb74d323c", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f26cdac-ee47-4bb5-ba95-4a545f172cbd", "565c2353-8027-401f-b3b8-d871478901e9", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c60abd0-1e9a-4b83-9e56-b580636482e3", "fb2f79ac-d271-437f-9078-20af178b2cc7", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f26cdac-ee47-4bb5-ba95-4a545f172cbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5293289c-22de-42c9-b718-f7be427035e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c60abd0-1e9a-4b83-9e56-b580636482e3");

            migrationBuilder.DropColumn(
                name: "PaymenId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "OrderDetails");

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
    }
}
