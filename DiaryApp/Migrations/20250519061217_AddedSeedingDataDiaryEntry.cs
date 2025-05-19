using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "This is the first entry in the diary.", new DateTime(2024, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "First Entry" },
                    { 2, "This is the second entry in the diary.", new DateTime(2024, 5, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Second Entry" },
                    { 3, "This is the third entry in the diary.", new DateTime(2024, 5, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), "Third Entry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
