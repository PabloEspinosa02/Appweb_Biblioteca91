using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi91.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    PkAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.PkAutor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PKrol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PKrol);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    PkLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkAutor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.PkLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_FkAutor",
                        column: x => x.FkAutor,
                        principalTable: "Autores",
                        principalColumn: "PkAutor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Pkusuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fkrol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Pkusuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_Fkrol",
                        column: x => x.Fkrol,
                        principalTable: "Roles",
                        principalColumn: "PKrol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PKrol", "Nombre" },
                values: new object[] { 1, "sa" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Pkusuario", "Fkrol", "Nombre", "Password", "User" },
                values: new object[] { 1, 1, "Pablo", "123", "Usuario1" });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_FkAutor",
                table: "Libros",
                column: "FkAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Fkrol",
                table: "Usuarios",
                column: "Fkrol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
