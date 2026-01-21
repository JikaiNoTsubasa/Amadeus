using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace amadeus_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedTasksAndPhases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectTaskId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CMDBId",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CMDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    ArchivedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMDB_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CMDB_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CMDB_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CMDB_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    ArchivedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPhase_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    PhaseId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ExpectedTimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    ArchivedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectPhase_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTask_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTask_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTask_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegisteredTaskTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTaskId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    ArchivedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredTaskTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_ProjectTask_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredTaskTime_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectTaskId",
                table: "Users",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CMDBId",
                table: "Projects",
                column: "CMDBId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CMDB_ArchivedById",
                table: "CMDB",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_CMDB_CreatedById",
                table: "CMDB",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CMDB_DeletedById",
                table: "CMDB",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CMDB_UpdatedById",
                table: "CMDB",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ArchivedById",
                table: "ProjectPhase",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_CreatedById",
                table: "ProjectPhase",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_DeletedById",
                table: "ProjectPhase",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_ProjectId",
                table: "ProjectPhase",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhase_UpdatedById",
                table: "ProjectPhase",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ArchivedById",
                table: "ProjectTask",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_CreatedById",
                table: "ProjectTask",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_DeletedById",
                table: "ProjectTask",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_UpdatedById",
                table: "ProjectTask",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_ArchivedById",
                table: "RegisteredTaskTime",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_CreatedById",
                table: "RegisteredTaskTime",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_DeletedById",
                table: "RegisteredTaskTime",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_ProjectTaskId",
                table: "RegisteredTaskTime",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_UpdatedById",
                table: "RegisteredTaskTime",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTaskTime_UserId",
                table: "RegisteredTaskTime",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CMDB_CMDBId",
                table: "Projects",
                column: "CMDBId",
                principalTable: "CMDB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProjectTask_ProjectTaskId",
                table: "Users",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CMDB_CMDBId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProjectTask_ProjectTaskId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CMDB");

            migrationBuilder.DropTable(
                name: "RegisteredTaskTime");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "ProjectPhase");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectTaskId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CMDBId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CMDBId",
                table: "Projects");
        }
    }
}
