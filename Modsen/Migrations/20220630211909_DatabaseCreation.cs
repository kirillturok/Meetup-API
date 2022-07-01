using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modsen.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.CompanyId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "CompanyId", "Address", "Description", "Name", "Organizer", "Plan", "Speaker", "Time" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Minsk", "Some talks about economics", "Economical discussion", "Ivanov Ivan Ivanovich", "Speak, eat, go home", "Ivanov Ivan Ivanovich", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "CompanyId", "Address", "Description", "Name", "Organizer", "Plan", "Speaker", "Time" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "USA", "Billie Eilish's concert", "Concert", "Billie Eilish", "some plan...", "Billie Eilish", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
