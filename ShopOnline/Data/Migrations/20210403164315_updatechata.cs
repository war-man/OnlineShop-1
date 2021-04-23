using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class updatechata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e2ce704-2129-4712-b82b-9c4f2686dc13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6069be15-ccc5-475a-95c0-c1e3018c1bf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df1f24f4-6e0d-4510-ab27-5da980dc53bb");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Chats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2cae7a6-3c58-4868-bcbf-7d6796c948b0", "ddaa187d-7786-4b20-be76-eeb5c4432f1f", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f374c3ee-d380-4de5-b205-dee1e135dca7", "458ad96b-8639-4f8f-99d5-8fb7d5a4b5f4", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88103c27-159d-4641-94ba-d249ec0455a4", "1a6140c0-770a-4402-8fa3-ab9213515707", "Customer", "Customer" });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88103c27-159d-4641-94ba-d249ec0455a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2cae7a6-3c58-4868-bcbf-7d6796c948b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f374c3ee-d380-4de5-b205-dee1e135dca7");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Chats");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6069be15-ccc5-475a-95c0-c1e3018c1bf9", "4b90917e-c6a5-4d77-8b02-4a23de9920d6", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df1f24f4-6e0d-4510-ab27-5da980dc53bb", "b5d46ab6-1634-436b-8125-002552e0a424", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e2ce704-2129-4712-b82b-9c4f2686dc13", "5acbf460-931d-4679-a9bb-be5cb5f93f19", "Customer", "Customer" });
        }
    }
}
