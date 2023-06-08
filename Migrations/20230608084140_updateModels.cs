using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("4ba89b80-809f-48b1-8ed2-751d4aaaf649"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5b61ef80-d86b-490f-b01e-7cb5e0fb15d9"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("9d1422d3-8b56-4864-8a34-eabdaf1e6c1a"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f7f5482c-c59e-4740-8614-6e58281f2ebe"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("48d5ca88-4d46-431e-b194-8e85214cdb52"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("b60f3b7d-c77a-4089-8298-92244c822776"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("f80e135e-e91c-459c-8235-c185a7c38723"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Fio" },
                values: new object[,]
                {
                    { new Guid("6e677623-4745-4f4e-9955-501d95aac980"), new DateOnly(1828, 8, 28), "Толстой Л.Н." },
                    { new Guid("6fcd3229-b28e-4f8d-a4c3-56502e36a0a4"), new DateOnly(1860, 1, 17), "Чехов А.П." },
                    { new Guid("99db2a14-f4a9-42c1-a2d1-266a0f0d02b9"), new DateOnly(1821, 10, 30), "Достоевский Ф.М." },
                    { new Guid("fbd1ecea-ec9d-4172-a825-feae7e42422d"), new DateOnly(1799, 6, 6), "Пушкин А.С." }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Роман" },
                    { 11, "Рассказ" },
                    { 12, "Повесть" },
                    { 13, "Психология" },
                    { 14, "Стихи" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("69935fee-dbe4-4ab1-916d-06d3d238f240"), "Macmillan" },
                    { new Guid("707c8cab-6229-4f03-8b45-822e28da5b26"), "Pinguin" },
                    { new Guid("e7c40e9a-5b14-49ec-851f-8d38bf232336"), "Harper Collins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6e677623-4745-4f4e-9955-501d95aac980"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6fcd3229-b28e-4f8d-a4c3-56502e36a0a4"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("99db2a14-f4a9-42c1-a2d1-266a0f0d02b9"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("fbd1ecea-ec9d-4172-a825-feae7e42422d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("69935fee-dbe4-4ab1-916d-06d3d238f240"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("707c8cab-6229-4f03-8b45-822e28da5b26"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: new Guid("e7c40e9a-5b14-49ec-851f-8d38bf232336"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Fio" },
                values: new object[,]
                {
                    { new Guid("4ba89b80-809f-48b1-8ed2-751d4aaaf649"), new DateOnly(1799, 6, 6), "Пушкин А.С." },
                    { new Guid("5b61ef80-d86b-490f-b01e-7cb5e0fb15d9"), new DateOnly(1828, 8, 28), "Толстой Л.Н." },
                    { new Guid("9d1422d3-8b56-4864-8a34-eabdaf1e6c1a"), new DateOnly(1821, 10, 30), "Достоевский Ф.М." },
                    { new Guid("f7f5482c-c59e-4740-8614-6e58281f2ebe"), new DateOnly(1860, 1, 17), "Чехов А.П." }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("48d5ca88-4d46-431e-b194-8e85214cdb52"), "Macmillan" },
                    { new Guid("b60f3b7d-c77a-4089-8298-92244c822776"), "Harper Collins" },
                    { new Guid("f80e135e-e91c-459c-8235-c185a7c38723"), "Pinguin" }
                });
        }
    }
}
