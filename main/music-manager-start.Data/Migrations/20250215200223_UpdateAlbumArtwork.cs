using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_manager_starter.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlbumArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverArtUrl",
                table: "Songs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Songs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/SomethingReal.jpg", "Jul 28, 2023" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2a76a0b1-b3e1-4ff0-9aa5-5f5e4c81bc45"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/NotesOnARiver.jpg", "Jan 27, 2023" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/WhenThePartysOver.jpg", "Mar 29, 2019" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("6f47c84f-4a7d-4e83-8b8f-1829f0eafca3"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/spiritbox.jpg", "Sep 17, 2021" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/TheGreatEscape.jpg", "Dec 11, 2020" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("d94aa1d4-75ee-4f7a-a89f-f77de7050c8d"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/SweaterWeather.jpg", "Apr 23, 2013" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fa38a0ed-4f00-48e2-b9c5-5d68f9c0ef41"),
                columns: new[] { "CoverArtUrl", "ReleaseDate" },
                values: new object[] { "/images/albums/FlowerShops.jpg", "Dec 31, 2021" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverArtUrl",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Songs");
        }
    }
}
