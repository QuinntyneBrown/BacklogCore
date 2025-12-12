using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;
public partial class AddStoryEffortProperty : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Effort",
            table: "Stories",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Effort",
            table: "Stories");
    }
}