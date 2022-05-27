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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
