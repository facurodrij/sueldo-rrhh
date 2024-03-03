using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sueldo_rrhh.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CUIT = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RazonSocial = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feriado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    EsNacional = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feriado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaConvenio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Agrupamiento = table.Column<char>(type: "TEXT", nullable: false),
                    SueldoBasico = table.Column<double>(type: "REAL", nullable: false),
                    ConvenioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaConvenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaConvenio_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Remunerativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: true),
                    ConvenioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concepto_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VigenteDesde = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VigenteHasta = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CUIL = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genero = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoCivil = table.Column<int>(type: "INTEGER", nullable: false),
                    Domicilio = table.Column<string>(type: "TEXT", nullable: false),
                    Hijos = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaEgreso = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CVU = table.Column<string>(type: "TEXT", maxLength: 22, nullable: true),
                    CBU = table.Column<string>(type: "TEXT", maxLength: 22, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaHistorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaHistorial_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaConvenioId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HorasSemanales = table.Column<int>(type: "INTEGER", nullable: false),
                    AdicionalEmpresa = table.Column<double>(type: "REAL", nullable: true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_CategoriaConvenio_CategoriaConvenioId",
                        column: x => x.CategoriaConvenioId,
                        principalTable: "CategoriaConvenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contrato_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeriadoTrabajado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FeriadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasTrabajadas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeriadoTrabajado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeriadoTrabajado_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeriadoTrabajado_Feriado_FeriadoId",
                        column: x => x.FeriadoId,
                        principalTable: "Feriado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoraExtra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Horas = table.Column<int>(type: "INTEGER", nullable: false),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraExtra_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Periodo = table.Column<string>(type: "TEXT", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AdicionalAsistencia = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibo_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motivo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRecibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReciboId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Unidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRecibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleRecibo_Recibo_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Convenio",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Comercio (CCT 130/75)" });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "CUIT", "Categoria", "Direccion", "Email", "FechaRegistro", "Nombre", "RazonSocial", "Telefono" },
                values: new object[] { 1, "12345678901", "Comercio", "Direccion 1", "stockcar@localhost", new DateTime(2024, 3, 2, 22, 22, 4, 194, DateTimeKind.Local).AddTicks(5923), "StockCar", "StockCar SA", "123456789" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "EsNacional", "Fecha", "Motivo" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Año Nuevo" },
                    { 2, false, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnaval" },
                    { 3, false, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnaval" },
                    { 4, true, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Día de la Memoria por la Verdad y la Justicia" },
                    { 5, false, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jueves Santo" },
                    { 6, false, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viernes Santo" },
                    { 7, true, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Día del Veterano y de los Caídos en la Guerra de Malvinas" },
                    { 8, true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Día del Trabajador" },
                    { 9, true, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Día de la Revolución de Mayo" }
                });

            migrationBuilder.InsertData(
                table: "Parametro",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[,]
                {
                    { 1, "horas mes", "200" },
                    { 2, "dias mes", "30" },
                    { 3, "dias año", "365" }
                });

            migrationBuilder.InsertData(
                table: "Persona",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "CategoriaConvenio",
                columns: new[] { "Id", "Agrupamiento", "ConvenioId", "Nombre", "SueldoBasico" },
                values: new object[,]
                {
                    { 1, 'A', 1, "Maestranza y Servicios", 441108.34000000003 },
                    { 2, 'B', 1, "Maestranza y Servicios", 442385.29999999999 },
                    { 3, 'C', 1, "Maestranza y Servicios", 446859.16999999998 },
                    { 4, 'A', 1, "Administrativo", 445901.45000000001 },
                    { 5, 'B', 1, "Administrativo", 447820.26000000001 },
                    { 6, 'C', 1, "Administrativo", 449736.83000000002 },
                    { 7, 'D', 1, "Administrativo", 455489.90999999997 },
                    { 8, 'E', 1, "Administrativo", 460283.01000000001 },
                    { 9, 'F', 1, "Administrativo", 467314.16999999998 },
                    { 10, 'A', 1, "Cajero", 447498.77000000002 },
                    { 11, 'B', 1, "Cajero", 449736.83000000002 },
                    { 12, 'C', 1, "Cajero", 452613.37 },
                    { 13, 'A', 1, "Auxiliar", 447498.77000000002 },
                    { 14, 'B', 1, "Auxiliar", 450694.54999999999 },
                    { 15, 'C', 1, "Auxiliar", 461241.85999999999 },
                    { 16, 'A', 1, "Auxiliar Especializado", 451335.28000000003 },
                    { 17, 'B', 1, "Auxiliar Especializado", 457087.22999999998 },
                    { 18, 'A', 1, "Vendedor", 447498.77000000002 },
                    { 19, 'B', 1, "Vendedor", 457088.35999999999 },
                    { 20, 'C', 1, "Vendedor", 460283.01000000001 },
                    { 21, 'D', 1, "Vendedor", 467314.16999999998 }
                });

            migrationBuilder.InsertData(
                table: "Concepto",
                columns: new[] { "Id", "ConvenioId", "Fecha", "Nombre", "Remunerativo", "Tipo", "Valor" },
                values: new object[,]
                {
                    { 1, 1, null, "Sueldo básico", true, null, 450000.0 },
                    { 2, 1, null, "Adicional por asistencia", true, null, 0.083299999999999999 },
                    { 3, 1, null, "Adicional por antiguedad", true, null, 0.01 },
                    { 4, 1, null, "Descuento jubilatorio", true, null, -0.11 },
                    { 5, 1, null, "Descuento obra social", true, null, -0.029999999999999999 },
                    { 6, 1, null, "Descuento sindical", true, null, -0.02 },
                    { 7, 1, null, "Descuento Ley 19.032 - INSSJP", true, null, -0.029999999999999999 },
                    { 8, 1, null, "Descuento FAECyS - Art. 100 CCT 130/75", true, null, -0.0050000000000000001 },
                    { 9, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incremento No Remunerativo - Acuerdo Febrero 2024", false, null, 0.20000000000000001 },
                    { 10, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acuerdo Febrero 2024 Presentismo", false, null, 0.0166 },
                    { 11, 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incremento No Remunerativo - Acuerdo Febrero 2024", false, null, 0.376 },
                    { 12, 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acuerdo Febrero 2024 Presentismo", false, null, 0.031300000000000001 },
                    { 13, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incremento No Remunerativo - Acuerdo Febrero 2024", false, null, 0.376 },
                    { 14, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acuerdo Febrero 2024 Presentismo", false, null, 0.031300000000000001 }
                });

            migrationBuilder.InsertData(
                table: "PersonaHistorial",
                columns: new[] { "Id", "CBU", "CUIL", "CVU", "Domicilio", "EstadoCivil", "FechaEgreso", "FechaIngreso", "FechaNacimiento", "Genero", "Hijos", "NombreCompleto", "PersonaId", "VigenteDesde", "VigenteHasta" },
                values: new object[] { 1, null, "20345678901", null, "Direccion 2", 0, null, new DateTime(2024, 3, 2, 22, 22, 4, 194, DateTimeKind.Local).AddTicks(6056), new DateTime(2000, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Admin", 1, new DateTime(2024, 3, 2, 22, 22, 4, 194, DateTimeKind.Local).AddTicks(6049), null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaConvenio_ConvenioId",
                table: "CategoriaConvenio",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepto_ConvenioId",
                table: "Concepto",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_CategoriaConvenioId",
                table: "Contrato",
                column: "CategoriaConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_EmpresaId",
                table: "Contrato",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_PersonaId",
                table: "Contrato",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibo_ReciboId",
                table: "DetalleRecibo",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_CUIT",
                table: "Empresa",
                column: "CUIT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeriadoTrabajado_ContratoId_FeriadoId",
                table: "FeriadoTrabajado",
                columns: new[] { "ContratoId", "FeriadoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeriadoTrabajado_FeriadoId",
                table: "FeriadoTrabajado",
                column: "FeriadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraExtra_ContratoId",
                table: "HoraExtra",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaHistorial_PersonaId",
                table: "PersonaHistorial",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_ContratoId",
                table: "Recibo",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_ContratoId",
                table: "Solicitud",
                column: "ContratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Concepto");

            migrationBuilder.DropTable(
                name: "DetalleRecibo");

            migrationBuilder.DropTable(
                name: "FeriadoTrabajado");

            migrationBuilder.DropTable(
                name: "HoraExtra");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "PersonaHistorial");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "Feriado");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "CategoriaConvenio");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Convenio");
        }
    }
}
