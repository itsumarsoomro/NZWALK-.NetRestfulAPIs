using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstRestfulAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b9c2ce9d-f7c6-4a15-9436-9c8a8318777a"), "Hard" },
                    { new Guid("e40053c1-b804-4c40-95c1-8fc321291e8e"), "Easy" },
                    { new Guid("f6aea21c-22c4-4da7-bbdb-46a36f230115"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("152b9ea2-3e52-46e4-b60e-2c13236c3848"), "AKL", "Auckland", "img.jpg" },
                    { new Guid("25e1acd0-ddde-4b01-9a83-2ebd4330a52c"), "BNG", "Bangladesh", "img.jpg" },
                    { new Guid("5262e70b-5aa5-440c-bac2-2b219fb63325"), "PAK", "Pakistan", "img.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b9c2ce9d-f7c6-4a15-9436-9c8a8318777a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e40053c1-b804-4c40-95c1-8fc321291e8e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f6aea21c-22c4-4da7-bbdb-46a36f230115"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("152b9ea2-3e52-46e4-b60e-2c13236c3848"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("25e1acd0-ddde-4b01-9a83-2ebd4330a52c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("5262e70b-5aa5-440c-bac2-2b219fb63325"));
        }
    }
}
