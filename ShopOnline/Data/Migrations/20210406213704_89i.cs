using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class _89i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToCategories",
                table: "ToCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c83fa9e4-40ae-49bc-9180-e94fc099306b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc3b6899-ba31-452a-aeb9-71e4bb70472f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a4ec97-bf86-4361-944c-c26f998750a5");

            migrationBuilder.RenameTable(
                name: "ToCategories",
                newName: "TopCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopCategories",
                table: "TopCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07304c47-e9c9-4fac-95dc-2e9c99ffa895", "9c80e403-93a8-46f9-9758-19b64770e91d", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95017154-e438-4208-89ee-7beff71cad1a", "70b172ec-1bde-4139-8df6-163ce48a2033", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72b60963-9093-4828-bb29-0e0648bd9b38", "73686645-f76d-4c77-b373-fde64fd579e3", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TopCategories",
                table: "TopCategories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07304c47-e9c9-4fac-95dc-2e9c99ffa895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b60963-9093-4828-bb29-0e0648bd9b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95017154-e438-4208-89ee-7beff71cad1a");

            migrationBuilder.RenameTable(
                name: "TopCategories",
                newName: "ToCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToCategories",
                table: "ToCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7a4ec97-bf86-4361-944c-c26f998750a5", "5e535842-b661-47ef-950f-6bad60d55345", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c83fa9e4-40ae-49bc-9180-e94fc099306b", "4327c690-782f-43a8-903b-064005b2c965", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc3b6899-ba31-452a-aeb9-71e4bb70472f", "83bcaff6-6620-4407-b818-88d2ea07c8b3", "Customer", "Customer" });
        }
    }
}
