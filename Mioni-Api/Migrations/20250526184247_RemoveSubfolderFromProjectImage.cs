using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mioni.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSubfolderFromProjectImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subfolder",
                table: "ProjectImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subfolder",
                table: "ProjectImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
