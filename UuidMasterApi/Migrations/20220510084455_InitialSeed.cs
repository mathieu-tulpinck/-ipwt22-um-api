using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UuidMasterApi.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Uuid", "EntityType", "EntityVersion", "Source", "SourceEntityId" },
                values: new object[] { new Guid("1a908081-21d3-4f28-952d-584f4490b3a8"), "user", 1, "FrontEnd", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Uuid",
                keyValue: new Guid("1a908081-21d3-4f28-952d-584f4490b3a8"));
        }
    }
}
