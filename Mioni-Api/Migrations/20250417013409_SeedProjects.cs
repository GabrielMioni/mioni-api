using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mioni_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Project 1", "Seeded Project 1", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Description for Project 2", "Seeded Project 2", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
