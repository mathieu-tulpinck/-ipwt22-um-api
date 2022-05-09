using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UuidMasterApi.Migrations
{
    public partial class ResourcesTableAlterSourceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Uuid",
                keyValue: new Guid("6b084a13-3a05-4a0e-9464-5e6dd624b36b"));

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Resources",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Uuid", "EntityType", "EntityVersion", "Source", "SourceEntityId" },
                values: new object[] { new Guid("a40613f5-96ca-47ed-9e7c-b32103d36a9a"), "user", 1, "FrontEnd", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Uuid",
                keyValue: new Guid("a40613f5-96ca-47ed-9e7c-b32103d36a9a"));

            migrationBuilder.AlterColumn<int>(
                name: "Source",
                table: "Resources",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Uuid", "EntityType", "EntityVersion", "Source", "SourceEntityId" },
                values: new object[] { new Guid("6b084a13-3a05-4a0e-9464-5e6dd624b36b"), "user", 1, 2, 1 });
        }
    }
}
