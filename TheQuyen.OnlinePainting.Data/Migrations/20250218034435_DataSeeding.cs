using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheQuyen.OnlinePainting.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Bio", "BirthDate", "Name", "Nationality", "Website" },
                values: new object[,]
                {
                    { 1, "No", new DateTime(2003, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ma The Quyen", "Viet Nam", "PaintingOnline.Com" },
                    { 2, "A sample artist bio", new DateTime(2003, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Van Do", "VN", "DoNguyen.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);
        }
    }
}
