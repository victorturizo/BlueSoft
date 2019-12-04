using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreBluesoft.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLibro = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    AutoresIdAutor = table.Column<int>(nullable: false),
                    CategoriasIdCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AutoresIdAutor",
                        column: x => x.AutoresIdAutor,
                        principalTable: "Authors",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoriasIdCategoria",
                        column: x => x.CategoriasIdCategoria,
                        principalTable: "Categories",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutoresIdAutor",
                table: "Books",
                column: "AutoresIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoriasIdCategoria",
                table: "Books",
                column: "CategoriasIdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
