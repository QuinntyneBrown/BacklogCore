using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;
public partial class AddUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.UserId);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Users");
    }
}