using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mioni_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSortOrderToProjectImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProjectImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProjectImages");
        }
    }
}
