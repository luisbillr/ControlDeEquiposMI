using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlDeEquiposMI.Migrations
{
    public partial class CreateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoJugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoJugador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pasaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstadoJugador",
                columns: new[] { "Id", "FechaCreacion", "Nombre" },
                values: new object[] { 1, new DateTime(2021, 8, 5, 13, 26, 51, 988, DateTimeKind.Local).AddTicks(5034), "Activo" });

            migrationBuilder.InsertData(
                table: "EstadoJugador",
                columns: new[] { "Id", "FechaCreacion", "Nombre" },
                values: new object[] { 2, new DateTime(2021, 8, 5, 13, 26, 51, 988, DateTimeKind.Local).AddTicks(5572), "Cancelado" });

            migrationBuilder.InsertData(
                table: "EstadoJugador",
                columns: new[] { "Id", "FechaCreacion", "Nombre" },
                values: new object[] { 3, new DateTime(2021, 8, 5, 13, 26, 51, 988, DateTimeKind.Local).AddTicks(5579), "AgenteLibre" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "EstadoJugador");

            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
