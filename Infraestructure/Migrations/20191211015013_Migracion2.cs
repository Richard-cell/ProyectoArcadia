using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Asignatura_AsignaturaId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_AsignaturaId",
                table: "Nota");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Nota_AsignaturaId",
                table: "Nota",
                column: "AsignaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Asignatura_AsignaturaId",
                table: "Nota",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
