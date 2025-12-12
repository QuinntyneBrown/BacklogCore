using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;
public partial class AddAttachments : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Attachment",
            columns: table => new
            {
                StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DigitalAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Attachment", x => new { x.StoryId, x.Id });
                table.ForeignKey(
                    name: "FK_Attachment_Stories_StoryId",
                    column: x => x.StoryId,
                    principalTable: "Stories",
                    principalColumn: "StoryId",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Attachment");
    }
}