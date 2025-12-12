using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;
public partial class AddSprint : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Sprints",
            columns: table => new
            {
                SprintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                End = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sprints", x => x.SprintId);
            });

        migrationBuilder.CreateTable(
            name: "SprintStory",
            columns: table => new
            {
                SprintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SprintStory", x => new { x.SprintId, x.Id });
                table.ForeignKey(
                    name: "FK_SprintStory_Sprints_SprintId",
                    column: x => x.SprintId,
                    principalTable: "Sprints",
                    principalColumn: "SprintId",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SprintStory");

        migrationBuilder.DropTable(
            name: "Sprints");
    }
}
}
