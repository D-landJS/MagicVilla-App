using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_villas",
                table: "villas");

            migrationBuilder.RenameTable(
                name: "villas",
                newName: "Villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas",
                table: "Villas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas",
                table: "Villas");

            migrationBuilder.RenameTable(
                name: "Villas",
                newName: "villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_villas",
                table: "villas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4731), new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4739) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4741), new DateTime(2023, 5, 28, 2, 12, 3, 399, DateTimeKind.Local).AddTicks(4742) });
        }
    }
}
