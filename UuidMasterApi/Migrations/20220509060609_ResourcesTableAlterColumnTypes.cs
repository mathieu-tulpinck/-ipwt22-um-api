using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UuidMasterApi.Migrations
{
    public partial class ResourcesTableAlterColumnTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Uuid",
                keyValue: new Guid("fed92226-4b82-47da-a0e5-85855faa9a17"));

            migrationBuilder.AlterColumn<int>(
                name: "SourceEntityId",
                table: "Resources",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.AlterColumn<int>(
                name: "EntityVersion",
                table: "Resources",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Uuid", "EntityType", "EntityVersion", "Source", "SourceEntityId" },
                values: new object[] { new Guid("6b084a13-3a05-4a0e-9464-5e6dd624b36b"), "user", 1, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Uuid",
                keyValue: new Guid("6b084a13-3a05-4a0e-9464-5e6dd624b36b"));

            migrationBuilder.AlterColumn<decimal>(
                name: "SourceEntityId",
                table: "Resources",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "EntityVersion",
                table: "Resources",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Uuid", "EntityType", "EntityVersion", "Source", "SourceEntityId" },
                values: new object[] { new Guid("fed92226-4b82-47da-a0e5-85855faa9a17"), "user", 1m, 2, 1m });
        }
    }
}
