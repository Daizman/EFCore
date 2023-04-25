using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class seedDataForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Fio" },
                values: new object[,]
                {
                    { new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"), new DateOnly(1821, 10, 30), "Достоевский Ф.М." },
                    { new Guid("c245bdfd-d306-42dc-8c69-ba5980bb9364"), new DateOnly(1799, 6, 6), "Пушкин А.С." },
                    { new Guid("cf6b1fa1-5a2b-4bc4-b2bb-49e2d3163594"), new DateOnly(1828, 8, 28), "Толстой Л.Н." },
                    { new Guid("ffaaeb53-ce11-443a-b6b9-bcd5666936fa"), new DateOnly(1860, 1, 17), "Чехов А.П." }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("222f3ced-4584-46d6-965f-4aeb8b13c158"), "Macmillan" },
                    { new Guid("2af9b647-3dd3-424d-b1e1-97eb4bda5daa"), "Pinguin" },
                    { new Guid("828082d7-4da9-49c3-805a-efc2772b51af"), "Harper Collins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c245bdfd-d306-42dc-8c69-ba5980bb9364"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("cf6b1fa1-5a2b-4bc4-b2bb-49e2d3163594"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ffaaeb53-ce11-443a-b6b9-bcd5666936fa"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("222f3ced-4584-46d6-965f-4aeb8b13c158"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("2af9b647-3dd3-424d-b1e1-97eb4bda5daa"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("828082d7-4da9-49c3-805a-efc2772b51af"));
        }
    }
}
