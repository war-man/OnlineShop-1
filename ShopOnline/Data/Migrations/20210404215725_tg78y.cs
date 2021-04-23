using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class tg78y : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "528b5f46-a4c3-4f7f-94d9-f0008016f103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56994587-7c36-4024-8014-dba05930ef10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be40843-715f-4764-9202-2af4a23bc37b");

            migrationBuilder.CreateTable(
                name: "ImageUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PathImage = table.Column<string>(nullable: true),
                    Decripstion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUsers", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUsers");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56994587-7c36-4024-8014-dba05930ef10", "b773b037-ccd3-4ddc-a1e6-7e456f751bf4", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5be40843-715f-4764-9202-2af4a23bc37b", "817a2e65-5ac5-4c85-9acb-fb8fa4da6e0a", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "528b5f46-a4c3-4f7f-94d9-f0008016f103", "efbde61c-50b0-4e47-be86-8ad78e75b840", "Customer", "Customer" });
        }
    }
}
