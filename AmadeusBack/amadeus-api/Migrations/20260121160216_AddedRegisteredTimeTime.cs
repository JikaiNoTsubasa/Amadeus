using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amadeus_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegisteredTimeTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RegisteredTaskTime",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "TimeInMinutes",
                table: "RegisteredTaskTime",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RegisteredTaskTime");

            migrationBuilder.DropColumn(
                name: "TimeInMinutes",
                table: "RegisteredTaskTime");
        }
    }
}
