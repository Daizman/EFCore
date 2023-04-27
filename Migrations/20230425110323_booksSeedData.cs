using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class booksSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "PublishDate", "PublisherId", "Discriminator" },
                values: new object[,]
                {
                    { new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"), "Преступление и наказание", new DateOnly(1866, 01, 01), new Guid("222f3ced-4584-46d6-965f-4aeb8b13c158"), "Book" },
                    { new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72"), "Идиот", new DateOnly(1869, 01, 01), new Guid("2af9b647-3dd3-424d-b1e1-97eb4bda5daa"), "Book" },
                    { new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"), "Евгений Онегин", new DateOnly(1833, 01, 01), new Guid("2af9b647-3dd3-424d-b1e1-97eb4bda5daa"), "Book" },
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"), new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb") },
                    { new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"), new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72") },
                    { new Guid("c245bdfd-d306-42dc-8c69-ba5980bb9364"), new Guid("9b892213-4bda-4c44-9fab-fce08b90052d") },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"), new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"), new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("c245bdfd-d306-42dc-8c69-ba5980bb9364"), new Guid("9b892213-4bda-4c44-9fab-fce08b90052d") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6e1cd6b2-6303-439f-b1ab-0ed9dc258eeb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0f49df11-ec6f-48cf-827f-89d2639e2b72"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9b892213-4bda-4c44-9fab-fce08b90052d"));
        }
    }
}
