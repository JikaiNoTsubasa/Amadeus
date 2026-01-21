using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amadeus_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_ArchivedById",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_CreatedById",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_DeletedById",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_UpdatedById",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_ArchivedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_DeletedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_OwnerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_UpdatedById",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Project_UpdatedById",
                table: "Projects",
                newName: "IX_Projects_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Project_OwnerId",
                table: "Projects",
                newName: "IX_Projects_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_DeletedById",
                table: "Projects",
                newName: "IX_Projects_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Project_CustomerId",
                table: "Projects",
                newName: "IX_Projects_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_CreatedById",
                table: "Projects",
                newName: "IX_Projects_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ArchivedById",
                table: "Projects",
                newName: "IX_Projects_ArchivedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UpdatedById",
                table: "Customers",
                newName: "IX_Customers_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_DeletedById",
                table: "Customers",
                newName: "IX_Customers_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CreatedById",
                table: "Customers",
                newName: "IX_Customers_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ArchivedById",
                table: "Customers",
                newName: "IX_Customers_ArchivedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_ArchivedById",
                table: "Customers",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CreatedById",
                table: "Customers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_DeletedById",
                table: "Customers",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UpdatedById",
                table: "Customers",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ArchivedById",
                table: "Projects",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatedById",
                table: "Projects",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_DeletedById",
                table: "Projects",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UpdatedById",
                table: "Projects",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_ArchivedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CreatedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_DeletedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UpdatedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ArchivedById",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatedById",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_DeletedById",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UpdatedById",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UpdatedById",
                table: "Project",
                newName: "IX_Project_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_OwnerId",
                table: "Project",
                newName: "IX_Project_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_DeletedById",
                table: "Project",
                newName: "IX_Project_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CustomerId",
                table: "Project",
                newName: "IX_Project_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CreatedById",
                table: "Project",
                newName: "IX_Project_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ArchivedById",
                table: "Project",
                newName: "IX_Project_ArchivedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UpdatedById",
                table: "Customer",
                newName: "IX_Customer_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_DeletedById",
                table: "Customer",
                newName: "IX_Customer_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CreatedById",
                table: "Customer",
                newName: "IX_Customer_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ArchivedById",
                table: "Customer",
                newName: "IX_Customer_ArchivedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_ArchivedById",
                table: "Customer",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_CreatedById",
                table: "Customer",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_DeletedById",
                table: "Customer",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_UpdatedById",
                table: "Customer",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_ArchivedById",
                table: "Project",
                column: "ArchivedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_CreatedById",
                table: "Project",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_DeletedById",
                table: "Project",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_UpdatedById",
                table: "Project",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
