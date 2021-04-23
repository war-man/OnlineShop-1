using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class ỳughjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c142275-4610-4be7-bb49-24d25a94add1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7191274c-bafa-47d2-a909-37c2363bd38e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9fdacf7-64c0-456f-853e-1570fadf1197");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c142275-4610-4be7-bb49-24d25a94add1", "2452941e-b133-44c6-9c03-3e7f2be5a9f7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7191274c-bafa-47d2-a909-37c2363bd38e", "7195ef62-65d7-4bb5-91ad-3b3fa30192e0", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9fdacf7-64c0-456f-853e-1570fadf1197", "093f5b51-bbc0-4572-93c4-225217d1420c", "Customer", "Customer" });
        }
    }
}
