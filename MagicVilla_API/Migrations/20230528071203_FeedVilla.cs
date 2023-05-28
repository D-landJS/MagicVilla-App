using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class FeedVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updateDate",
                table: "villas",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "occupants",
                table: "villas",
                newName: "Occupants");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "villas",
                newName: "DateCreate");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenity", "DateCreate", "Details", "Fee", "ImageUrl", "MetersSquared", "Name", "Occupants", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4731), "", 200.0, "", 50, "Villa Real", 5, new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4739) },
                    { 2, "", new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4741), "", 150.0, "", 50, "Premium Vista a la Piscina", 4, new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4742) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Details",
                table: "villas");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "villas",
                newName: "updateDate");

            migrationBuilder.RenameColumn(
                name: "Occupants",
                table: "villas",
                newName: "occupants");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "villas",
                newName: "DateTime");
        }
    }
}
