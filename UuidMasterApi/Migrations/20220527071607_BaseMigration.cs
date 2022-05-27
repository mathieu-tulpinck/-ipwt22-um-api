using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UuidMasterApi.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    SourceEntityId = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "EntityType", "EntityVersion", "Source", "SourceEntityId", "Uuid" },
                values: new object[] { 1, "SESSION", 1, "FRONTEND", "78", "6c3df037-b316-484b-8a0e-7ec7d00a05a3" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "EntityType", "EntityVersion", "Source", "SourceEntityId", "Uuid" },
                values: new object[] { 2, "SESSION", 1, "CRM", "13", "6c3df037-b316-484b-8a0e-7ec7d00a05a3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
