using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sessions_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UsuarioCodigo",
                table: "Sessions",
                column: "UsuarioCodigo");
        }
    }
}
