using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backlog.Api.Migrations;

public partial class AddDigitalAssets : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_DependencyRelationships_Stories_StoryId",
            table: "DependencyRelationships");

        migrationBuilder.DropPrimaryKey(
            name: "PK_DependencyRelationships",
            table: "DependencyRelationships");

        migrationBuilder.RenameTable(
            name: "DependencyRelationships",
            newName: "DependencyRelationship");

        migrationBuilder.AddPrimaryKey(
            name: "PK_DependencyRelationship",
            table: "DependencyRelationship",
            columns: new[] { "StoryId", "Id" });

        migrationBuilder.CreateTable(
            name: "DigitalAssets",
            columns: table => new
            {
                DigitalAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Height = table.Column<float>(type: "real", nullable: false),
                Width = table.Column<float>(type: "real", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DigitalAssets", x => x.DigitalAssetId);
            });

        migrationBuilder.AddForeignKey(
            name: "FK_DependencyRelationship_Stories_StoryId",
            table: "DependencyRelationship",
            column: "StoryId",
            principalTable: "Stories",
            principalColumn: "StoryId",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_DependencyRelationship_Stories_StoryId",
            table: "DependencyRelationship");

        migrationBuilder.DropTable(
            name: "DigitalAssets");

        migrationBuilder.DropPrimaryKey(
            name: "PK_DependencyRelationship",
            table: "DependencyRelationship");

        migrationBuilder.RenameTable(
            name: "DependencyRelationship",
            newName: "DependencyRelationships");

        migrationBuilder.AddPrimaryKey(
            name: "PK_DependencyRelationships",
            table: "DependencyRelationships",
            columns: new[] { "StoryId", "Id" });

        migrationBuilder.AddForeignKey(
            name: "FK_DependencyRelationships_Stories_StoryId",
            table: "DependencyRelationships",
            column: "StoryId",
            principalTable: "Stories",
            principalColumn: "StoryId",
            onDelete: ReferentialAction.Cascade);
    }
}