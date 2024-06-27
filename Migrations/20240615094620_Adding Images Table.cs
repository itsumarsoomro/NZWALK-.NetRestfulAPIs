using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstRestfulAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2edf7f1b-bc18-4aa4-a233-a3deddc32450"), "AKL", "Auckland", "img.jpg" },
                    { new Guid("48484791-5fda-4edc-9a5a-beed30b0d0f3"), "PAK", "Pakistan", "img.jpg" },
                    { new Guid("62306ee5-48ac-4538-bf11-83100cb351a8"), "BNG", "Bangladesh", "img.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("2edf7f1b-bc18-4aa4-a233-a3deddc32450"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("48484791-5fda-4edc-9a5a-beed30b0d0f3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "id",
                keyValue: new Guid("62306ee5-48ac-4538-bf11-83100cb351a8"));

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
    }
}
