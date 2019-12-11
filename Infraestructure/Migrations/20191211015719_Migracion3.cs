using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AsignaturaId",
                table: "Nota",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Asignatura_AsignaturaId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_AsignaturaId",
                table: "Nota");

            migrationBuilder.AlterColumn<long>(
                name: "AsignaturaId",
                table: "Nota",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
