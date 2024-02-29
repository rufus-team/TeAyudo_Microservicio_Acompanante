using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
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
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompañante", x => x.AcompananteID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
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

            migrationBuilder.CreateTable(
                name: "AcompananteTag",
                columns: table => new
                {
                    AcompananteID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompananteTag", x => new { x.AcompananteID, x.TagID });
                    table.ForeignKey(
                        name: "FK_AcompananteTag_Acompañante_AcompananteID",
                        column: x => x.AcompananteID,
                        principalTable: "Acompañante",
                        principalColumn: "AcompananteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompananteTag_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Nombre" },
                values: new object[,]
                {
                    { 1, "Actitud positiva" },
                    { 2, "Compromiso" },
                    { 3, "Habilidades de comunicación" },
                    { 4, "Adaptabilidad" },
                    { 5, "Responsabilidad" },
                    { 6, "Iniciativa" },
                    { 7, "Ética laboral" },
                    { 8, "Honestidad" },
                    { 9, "Organización" },
                    { 10, "Aprendizaje continuo" },
                    { 11, "Paciencia" },
                    { 12, "Cariño" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcompananteTag_TagID",
                table: "AcompananteTag",
                column: "TagID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompananteTag");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Acompañante");
        }
    }
}
