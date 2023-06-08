using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class bookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"), 10 },
                    { new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"), 13 },
                    { new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72"), 10 },
                    { new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"), 10 },
                    { new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"), 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[]
                {
                    new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"),
                    10
                });
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[]
                {
                    new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"),
                    13
                });
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[]
                {
                    new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72"),
                    10
                });
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[]
                {
                    new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"),
                    10
                });
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[]
                {
                    new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"),
                    14
                });
        }
    }
}
