using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sueldo_rrhh.Data.Migrations
{
    /// <inheritdoc />
    public partial class AreaDepartamentoPuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AspNetUsers_UserId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Web",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Empleados",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Empleados",
                newName: "NombreCompleto");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_UserId",
                table: "Empleados",
                newName: "IX_Empleados_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "PuestoId",
                table: "Empleados",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puestos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EmpresaId",
                table: "Areas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_AreaId",
                table: "Departamentos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_DepartamentoId",
                table: "Puestos",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AspNetUsers_ApplicationUserId",
                table: "Empleados",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_PuestoId",
                table: "Empleados",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AspNetUsers_ApplicationUserId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_PuestoId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PuestoId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "Empleados",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Empleados",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_ApplicationUserId",
                table: "Empleados",
                newName: "IX_Empleados_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Empresas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Web",
                table: "Empresas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Empleados",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empleados",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AspNetUsers_UserId",
                table: "Empleados",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
