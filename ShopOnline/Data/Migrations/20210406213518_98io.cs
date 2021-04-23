using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class _98io : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1569d4e1-9f67-46d2-a282-e2e4acd9db32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af8163c-a694-4d97-b283-9f429dec36ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35e8d85-5e47-45ef-b558-d6e93cbe3415");

            migrationBuilder.CreateTable(
                name: "ToCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Decripstion = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToCategories", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToCategories");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1569d4e1-9f67-46d2-a282-e2e4acd9db32", "d7b3d7dd-2452-4cd5-a118-fd15268bb556", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6af8163c-a694-4d97-b283-9f429dec36ad", "18a14a65-19da-43fc-92b0-6c0e1f492aa2", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f35e8d85-5e47-45ef-b558-d6e93cbe3415", "8e2d6e6e-45b3-48cf-9ad2-3d736fd5cf8c", "Customer", "Customer" });
        }
    }
}
