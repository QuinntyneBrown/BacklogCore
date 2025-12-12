using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Bugs",
            columns: table => new
            {
                BugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bugs", x => x.BugId);
            });

        migrationBuilder.CreateTable(
            name: "CompetencyLevels",
            columns: table => new
            {
                CompetencyLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CompetencyLevels", x => x.CompetencyLevelId);
            });

        migrationBuilder.CreateTable(
            name: "Profiles",
            columns: table => new
            {
                ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Profiles", x => x.ProfileId);
            });

        migrationBuilder.CreateTable(
            name: "Statuses",
            columns: table => new
            {
                StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Statuses", x => x.StatusId);
            });

        migrationBuilder.CreateTable(
            name: "StoredEvents",
            columns: table => new
            {
                StoredEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                StreamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Aggregate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AggregateDotNetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Sequence = table.Column<int>(type: "int", nullable: false),
                Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DotNetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                Version = table.Column<int>(type: "int", nullable: false),
                CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoredEvents", x => x.StoredEventId);
            });

        migrationBuilder.CreateTable(
            name: "Stories",
            columns: table => new
            {
                StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AcceptanceCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                JiraUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stories", x => x.StoryId);
            });

        migrationBuilder.CreateTable(
            name: "TaskItems",
            columns: table => new
            {
                TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TaskItems", x => x.TaskItemId);
            });

        migrationBuilder.CreateTable(
            name: "Technologies",
            columns: table => new
            {
                TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
            });

        migrationBuilder.CreateTable(
            name: "DependencyRelationships",
            columns: table => new
            {
                StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DependsOn = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DependencyRelationships", x => new { x.StoryId, x.Id });
                table.ForeignKey(
                    name: "FK_DependencyRelationships_Stories_StoryId",
                    column: x => x.StoryId,
                    principalTable: "Stories",
                    principalColumn: "StoryId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "SkillRequirement",
            columns: table => new
            {
                StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Technology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CompetencyLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SkillRequirement", x => new { x.StoryId, x.Id });
                table.ForeignKey(
                    name: "FK_SkillRequirement_Stories_StoryId",
                    column: x => x.StoryId,
                    principalTable: "Stories",
                    principalColumn: "StoryId",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Bugs");

        migrationBuilder.DropTable(
            name: "CompetencyLevels");

        migrationBuilder.DropTable(
            name: "DependencyRelationships");

        migrationBuilder.DropTable(
            name: "Profiles");

        migrationBuilder.DropTable(
            name: "SkillRequirement");

        migrationBuilder.DropTable(
            name: "Statuses");

        migrationBuilder.DropTable(
            name: "StoredEvents");

        migrationBuilder.DropTable(
            name: "TaskItems");

        migrationBuilder.DropTable(
            name: "Technologies");

        migrationBuilder.DropTable(
            name: "Stories");
    }
}
}
