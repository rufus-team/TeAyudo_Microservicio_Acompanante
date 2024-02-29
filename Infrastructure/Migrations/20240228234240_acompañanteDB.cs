using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class acompañanteDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acompañante",
                columns: table => new
                {
                    AcompananteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompañante", x => x.AcompananteID);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    AcompananteID = table.Column<int>(type: "int", nullable: false),
                    Lunes = table.Column<int>(type: "int", nullable: false),
                    Martes = table.Column<int>(type: "int", nullable: false),
                    Miercoles = table.Column<int>(type: "int", nullable: false),
                    Jueves = table.Column<int>(type: "int", nullable: false),
                    Viernes = table.Column<int>(type: "int", nullable: false),
                    Sabado = table.Column<int>(type: "int", nullable: false),
                    Domingo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.AcompananteID);
                    table.ForeignKey(
                        name: "FK_Horarios_Acompañante_AcompananteID",
                        column: x => x.AcompananteID,
                        principalTable: "Acompañante",
                        principalColumn: "AcompananteID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Acompañante");
        }
    }
}
