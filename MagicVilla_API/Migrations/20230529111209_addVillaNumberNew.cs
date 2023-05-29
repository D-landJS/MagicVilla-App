using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumberNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updateDate",
                table: "VillaNumbers",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "VillaNumbers",
                newName: "DateCreate");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 29, 6, 12, 9, 104, DateTimeKind.Local).AddTicks(8589), new DateTime(2023, 5, 29, 6, 12, 9, 104, DateTimeKind.Local).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 29, 6, 12, 9, 104, DateTimeKind.Local).AddTicks(8600), new DateTime(2023, 5, 29, 6, 12, 9, 104, DateTimeKind.Local).AddTicks(8600) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "VillaNumbers",
                newName: "updateDate");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "VillaNumbers",
                newName: "createDate");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 29, 5, 49, 55, 975, DateTimeKind.Local).AddTicks(4431), new DateTime(2023, 5, 29, 5, 49, 55, 975, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 29, 5, 49, 55, 975, DateTimeKind.Local).AddTicks(4465), new DateTime(2023, 5, 29, 5, 49, 55, 975, DateTimeKind.Local).AddTicks(4466) });
        }
    }
}
