﻿// <auto-generated />
using System;
using Backlog.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backlog.Api.Migrations
{
    [DbContext(typeof(BacklogDbContext))]
    partial class BacklogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backlog.Api.Models.Bug", b =>
                {
                    b.Property<Guid>("BugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BugId");

                    b.ToTable("Bugs");
                });

            modelBuilder.Entity("Backlog.Api.Models.CompetencyLevel", b =>
                {
                    b.Property<Guid>("CompetencyLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompetencyLevelId");

                    b.ToTable("CompetencyLevels");
                });

            modelBuilder.Entity("Backlog.Api.Models.DigitalAsset", b =>
                {
                    b.Property<Guid>("DigitalAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Bytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("DigitalAssetId");

                    b.ToTable("DigitalAssets");
                });

            modelBuilder.Entity("Backlog.Api.Models.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Backlog.Api.Models.Sprint", b =>
                {
                    b.Property<Guid>("SprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("SprintId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("Backlog.Api.Models.Status", b =>
                {
                    b.Property<Guid>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Backlog.Api.Models.StoredEvent", b =>
                {
                    b.Property<Guid>("StoredEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Aggregate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AggregateDotNetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DotNetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<Guid>("StreamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("StoredEventId");

                    b.ToTable("StoredEvents");
                });

            modelBuilder.Entity("Backlog.Api.Models.Story", b =>
                {
                    b.Property<Guid>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcceptanceCriteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JiraUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoryId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("Backlog.Api.Models.TaskItem", b =>
                {
                    b.Property<Guid>("TaskItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TaskItemId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("Backlog.Api.Models.Technology", b =>
                {
                    b.Property<Guid>("TechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnologyId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Backlog.Api.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backlog.Api.Models.Sprint", b =>
                {
                    b.OwnsMany("Backlog.Api.Models.SprintStory", "SprintStories", b1 =>
                        {
                            b1.Property<Guid>("SprintId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<Guid>("StoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("SprintId", "Id");

                            b1.ToTable("SprintStory");

                            b1.WithOwner()
                                .HasForeignKey("SprintId");
                        });

                    b.Navigation("SprintStories");
                });

            modelBuilder.Entity("Backlog.Api.Models.Story", b =>
                {
                    b.OwnsMany("Backlog.Api.Models.Attachment", "Attachments", b1 =>
                        {
                            b1.Property<Guid>("StoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<Guid>("DigitalAssetId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("StoryId", "Id");

                            b1.ToTable("Attachment");

                            b1.WithOwner()
                                .HasForeignKey("StoryId");
                        });

                    b.OwnsMany("Backlog.Api.Models.DependencyRelationship", "DependsOn", b1 =>
                        {
                            b1.Property<Guid>("StoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("DependsOn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("StoryId", "Id");

                            b1.ToTable("DependencyRelationship");

                            b1.WithOwner()
                                .HasForeignKey("StoryId");
                        });

                    b.OwnsMany("Backlog.Api.Models.SkillRequirement", "SkillRequirements", b1 =>
                        {
                            b1.Property<Guid>("StoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CompetencyLevel")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Technology")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("StoryId", "Id");

                            b1.ToTable("SkillRequirement");

                            b1.WithOwner()
                                .HasForeignKey("StoryId");
                        });

                    b.Navigation("Attachments");

                    b.Navigation("DependsOn");

                    b.Navigation("SkillRequirements");
                });
#pragma warning restore 612, 618
        }
    }
}
