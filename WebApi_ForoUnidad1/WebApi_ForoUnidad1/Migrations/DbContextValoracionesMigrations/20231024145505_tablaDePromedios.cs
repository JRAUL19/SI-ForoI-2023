using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_ForoUnidad1.Migrations.DbContextValoracionesMigrations
{
    /// <inheritdoc />
    public partial class tablaDePromedios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "valoracion_promedio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<int>(type: "int", nullable: false),
                    promedio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valoracion_promedio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "valoraciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    puntuacion = table.Column<int>(type: "int", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    producto_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valoraciones", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "valoracion_promedio");

            migrationBuilder.DropTable(
                name: "valoraciones");
        }
    }
}
