using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amadeus_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedTablesToFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhase_Projects_ProjectId",
                table: "ProjectPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhase_Users_ArchivedById",
                table: "ProjectPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhase_Users_CreatedById",
                table: "ProjectPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhase_Users_DeletedById",
                table: "ProjectPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhase_Users_UpdatedById",
                table: "ProjectPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectPhase_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Projects_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Users_ArchivedById",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Users_CreatedById",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Users_DeletedById",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Users_UpdatedById",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredTaskTime_ProjectTask_ProjectTaskId",
                table: "RegisteredTaskTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProjectTask_ProjectTaskId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectPhase",
                table: "ProjectPhase");

            migrationBuilder.RenameTable(
                name: "ProjectTask",
                newName: "ProjectTasks");

            migrationBuilder.RenameTable(
                name: "ProjectPhase",
                newName: "ProjectPhases");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_UpdatedById",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_DeletedById",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_CreatedById",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ArchivedById",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ArchivedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhase_UpdatedById",
                table: "ProjectPhases",
                newName: "IX_ProjectPhases_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhase_ProjectId",
                table: "ProjectPhases",
                newName: "IX_ProjectPhases_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhase_DeletedById",
                table: "ProjectPhases",
                newName: "IX_ProjectPhases_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhase_CreatedById",
                table: "ProjectPhases",
                newName: "IX_ProjectPhases_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhase_ArchivedById",
                table: "ProjectPhases",
                newName: "IX_ProjectPhases_ArchivedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectPhases",
                table: "ProjectPhases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhases_Projects_ProjectId",
                table: "ProjectPhases",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhases_Users_ArchivedById",
                table: "ProjectPhases",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhases_Users_CreatedById",
                table: "ProjectPhases",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhases_Users_DeletedById",
                table: "ProjectPhases",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhases_Users_UpdatedById",
                table: "ProjectPhases",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectPhases_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "ProjectPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_ArchivedById",
                table: "ProjectTasks",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_CreatedById",
                table: "ProjectTasks",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_DeletedById",
                table: "ProjectTasks",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_UpdatedById",
                table: "ProjectTasks",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredTaskTime_ProjectTasks_ProjectTaskId",
                table: "RegisteredTaskTime",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProjectTasks_ProjectTaskId",
                table: "Users",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhases_Projects_ProjectId",
                table: "ProjectPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhases_Users_ArchivedById",
                table: "ProjectPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhases_Users_CreatedById",
                table: "ProjectPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhases_Users_DeletedById",
                table: "ProjectPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPhases_Users_UpdatedById",
                table: "ProjectPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectPhases_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_ArchivedById",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_CreatedById",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_DeletedById",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_UpdatedById",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredTaskTime_ProjectTasks_ProjectTaskId",
                table: "RegisteredTaskTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProjectTasks_ProjectTaskId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectPhases",
                table: "ProjectPhases");

            migrationBuilder.RenameTable(
                name: "ProjectTasks",
                newName: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "ProjectPhases",
                newName: "ProjectPhase");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_UpdatedById",
                table: "ProjectTask",
                newName: "IX_ProjectTask_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_DeletedById",
                table: "ProjectTask",
                newName: "IX_ProjectTask_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_CreatedById",
                table: "ProjectTask",
                newName: "IX_ProjectTask_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ArchivedById",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ArchivedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhases_UpdatedById",
                table: "ProjectPhase",
                newName: "IX_ProjectPhase_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhases_ProjectId",
                table: "ProjectPhase",
                newName: "IX_ProjectPhase_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhases_DeletedById",
                table: "ProjectPhase",
                newName: "IX_ProjectPhase_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhases_CreatedById",
                table: "ProjectPhase",
                newName: "IX_ProjectPhase_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPhases_ArchivedById",
                table: "ProjectPhase",
                newName: "IX_ProjectPhase_ArchivedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectPhase",
                table: "ProjectPhase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhase_Projects_ProjectId",
                table: "ProjectPhase",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhase_Users_ArchivedById",
                table: "ProjectPhase",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhase_Users_CreatedById",
                table: "ProjectPhase",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhase_Users_DeletedById",
                table: "ProjectPhase",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPhase_Users_UpdatedById",
                table: "ProjectPhase",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectPhase_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "ProjectPhase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Projects_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Users_ArchivedById",
                table: "ProjectTask",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Users_CreatedById",
                table: "ProjectTask",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Users_DeletedById",
                table: "ProjectTask",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Users_UpdatedById",
                table: "ProjectTask",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredTaskTime_ProjectTask_ProjectTaskId",
                table: "RegisteredTaskTime",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProjectTask_ProjectTaskId",
                table: "Users",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id");
        }
    }
}
