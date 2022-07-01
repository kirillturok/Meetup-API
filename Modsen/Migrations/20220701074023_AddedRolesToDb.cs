using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modsen.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bf987e6-9a49-443a-aa58-2772de2d4406", "eb72f5f3-a7c9-45e8-9499-492007e12d03", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a172f740-9848-4a83-b187-fdec772714af", "28b90938-a66a-46c0-bbce-a98d131d7a22", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bf987e6-9a49-443a-aa58-2772de2d4406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a172f740-9848-4a83-b187-fdec772714af");
        }
    }
}
