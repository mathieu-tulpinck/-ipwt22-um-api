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
                columns: new[] { "Id", "EntityType", "EntityVersion", "Source", "SourceEntityId", "Uuid" },
                values: new object[] { 1, "SESSION", 1, "FRONTEND", "78", "c49c1ae7-2d59-43b1-8b4a-cdac62df5632" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "EntityType", "EntityVersion", "Source", "SourceEntityId", "Uuid" },
                values: new object[] { 2, "SESSION", 1, "CRM", "13", "c49c1ae7-2d59-43b1-8b4a-cdac62df5632" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
