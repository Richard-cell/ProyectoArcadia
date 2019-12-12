using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudiante_AcudienteId",
                table: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_AcudienteId",
                table: "Estudiante",
                column: "AcudienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudiante_AcudienteId",
                table: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_AcudienteId",
                table: "Estudiante",
                column: "AcudienteId",
                unique: true);
        }
    }
}
