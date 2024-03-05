using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sueldo_rrhh.Data.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 3, 5, 10, 29, 36, 536, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "PersonaHistorial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaIngreso", "VigenteDesde" },
                values: new object[] { new DateTime(2024, 3, 5, 10, 29, 36, 536, DateTimeKind.Local).AddTicks(1709), new DateTime(2024, 3, 5, 10, 29, 36, 536, DateTimeKind.Local).AddTicks(1701) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 3, 5, 5, 46, 23, 598, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "PersonaHistorial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaIngreso", "VigenteDesde" },
                values: new object[] { new DateTime(2024, 3, 5, 5, 46, 23, 598, DateTimeKind.Local).AddTicks(8916), new DateTime(2024, 3, 5, 5, 46, 23, 598, DateTimeKind.Local).AddTicks(8907) });
        }
    }
}
