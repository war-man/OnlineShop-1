using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class _89dfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac9b32f4-f7c8-4a81-b457-e2bdbd694ebe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f7eeb2-3133-4e4a-ad18-690b45c99a00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f818a463-9ec4-4258-856d-f78f51ee4469");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f7eeb2-3133-4e4a-ad18-690b45c99a00", "90d21109-2976-4d44-8310-2f78d5a320a3", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac9b32f4-f7c8-4a81-b457-e2bdbd694ebe", "f19ec673-d706-4db9-bbbb-ae6d973252df", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f818a463-9ec4-4258-856d-f78f51ee4469", "f55069f0-573e-46f1-80a6-1d87a4ed4e87", "Customer", "Customer" });
        }
    }
}
