using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class TodasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibro_Autores_AutorId",
                table: "AutorLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibro_Libros_LibroId",
                table: "AutorLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Libros_LibroId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutorLibro",
                table: "AutorLibro");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameTable(
                name: "AutorLibro",
                newName: "AutorLibros");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_LibroId",
                table: "Comentarios",
                newName: "IX_Comentarios_LibroId");

            migrationBuilder.RenameIndex(
                name: "IX_AutorLibro_LibroId",
                table: "AutorLibros",
                newName: "IX_AutorLibros_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutorLibros",
                table: "AutorLibros",
                columns: new[] { "AutorId", "LibroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibros_Autores_AutorId",
                table: "AutorLibros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibros_Libros_LibroId",
                table: "AutorLibros",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Libros_LibroId",
                table: "Comentarios",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibros_Autores_AutorId",
                table: "AutorLibros");

            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibros_Libros_LibroId",
                table: "AutorLibros");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Libros_LibroId",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutorLibros",
                table: "AutorLibros");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comentario");

            migrationBuilder.RenameTable(
                name: "AutorLibros",
                newName: "AutorLibro");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_LibroId",
                table: "Comentario",
                newName: "IX_Comentario_LibroId");

            migrationBuilder.RenameIndex(
                name: "IX_AutorLibros_LibroId",
                table: "AutorLibro",
                newName: "IX_AutorLibro_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutorLibro",
                table: "AutorLibro",
                columns: new[] { "AutorId", "LibroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibro_Autores_AutorId",
                table: "AutorLibro",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibro_Libros_LibroId",
                table: "AutorLibro",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Libros_LibroId",
                table: "Comentario",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
