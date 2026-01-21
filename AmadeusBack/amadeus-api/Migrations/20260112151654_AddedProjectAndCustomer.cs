using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace amadeus_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectAndCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ContactName = table.Column<string>(type: "text", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Users_ArchivedById",
                        column: x => x.ArchivedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ArchivedById",
                table: "Customer",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CreatedById",
                table: "Customer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DeletedById",
                table: "Customer",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UpdatedById",
                table: "Customer",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ArchivedById",
                table: "Project",
                column: "ArchivedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DeletedById",
                table: "Project",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OwnerId",
                table: "Project",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedById",
                table: "Project",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
