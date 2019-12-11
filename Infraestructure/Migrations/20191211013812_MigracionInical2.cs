using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class MigracionInical2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acudiente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<long>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    EstratoSocial = table.Column<int>(nullable: false),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Parentezco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudiente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    NombreAsignatura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletin",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    GradoCurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<long>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    EstratoSocial = table.Column<int>(nullable: false),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    AñosExperiencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    FechaMatricula = table.Column<DateTime>(nullable: false),
                    NumeroDocumentosAdjuntados = table.Column<int>(nullable: false),
                    ValorMatricula = table.Column<float>(nullable: false),
                    EstadoMatricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocenteAsignatura",
                columns: table => new
                {
                    DocenteId = table.Column<long>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false),
                    AsignaturaId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteAsignatura", x => new { x.AsignaturaId, x.DocenteId });
                    table.ForeignKey(
                        name: "FK_DocenteAsignatura_Asignatura_AsignaturaId1",
                        column: x => x.AsignaturaId1,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocenteAsignatura_Docente_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteCurso",
                columns: table => new
                {
                    DocenteId = table.Column<long>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    CursoId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteCurso", x => new { x.CursoId, x.DocenteId });
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Curso_CursoId1",
                        column: x => x.CursoId1,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Docente_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<long>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    EstratoSocial = table.Column<int>(nullable: false),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    LugarNacimiento = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    RH = table.Column<string>(nullable: true),
                    NumeroHermanos = table.Column<int>(nullable: false),
                    LugarEntreHermanos = table.Column<int>(nullable: false),
                    SeguroSocial = table.Column<string>(nullable: true),
                    PuntajeSisben = table.Column<float>(nullable: false),
                    MatriculaId = table.Column<long>(nullable: false),
                    CursoId = table.Column<long>(nullable: true),
                    AcudienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiante_Acudiente_AcudienteId",
                        column: x => x.AcudienteId,
                        principalTable: "Acudiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiante_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiante_Matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    NotaPrimerPeriodo = table.Column<float>(nullable: false),
                    NotaSegundoPeriodo = table.Column<float>(nullable: false),
                    NotaTercerPeriodo = table.Column<float>(nullable: false),
                    NotaCuartoPeriodo = table.Column<float>(nullable: false),
                    PromedioNota = table.Column<float>(nullable: false),
                    AsignaturaId = table.Column<long>(nullable: false),
                    BoletinId = table.Column<long>(nullable: true),
                    EstudianteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Boletin_BoletinId",
                        column: x => x.BoletinId,
                        principalTable: "Boletin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nota_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PensionEscolar",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    FechaInicioPension = table.Column<DateTime>(nullable: false),
                    ValorPension = table.Column<float>(nullable: false),
                    EstudianteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionEscolar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PensionEscolar_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesCuota = table.Column<int>(nullable: false),
                    FechaPagoCuota = table.Column<DateTime>(nullable: false),
                    FechaLimitePagoCuota = table.Column<DateTime>(nullable: false),
                    ValorCuota = table.Column<float>(nullable: false),
                    ValorTotalAPagar = table.Column<float>(nullable: false),
                    EstadoCuota = table.Column<string>(nullable: true),
                    PensionEscolarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuota_PensionEscolar_PensionEscolarId",
                        column: x => x.PensionEscolarId,
                        principalTable: "PensionEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_PensionEscolarId",
                table: "Cuota",
                column: "PensionEscolarId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteAsignatura_AsignaturaId1",
                table: "DocenteAsignatura",
                column: "AsignaturaId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteAsignatura_DocenteId",
                table: "DocenteAsignatura",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_CursoId1",
                table: "DocenteCurso",
                column: "CursoId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_DocenteId",
                table: "DocenteCurso",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_AcudienteId",
                table: "Estudiante",
                column: "AcudienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_CursoId",
                table: "Estudiante",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_MatriculaId",
                table: "Estudiante",
                column: "MatriculaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_AsignaturaId",
                table: "Nota",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_BoletinId",
                table: "Nota",
                column: "BoletinId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EstudianteId",
                table: "Nota",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_PensionEscolar_EstudianteId",
                table: "PensionEscolar",
                column: "EstudianteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "DocenteAsignatura");

            migrationBuilder.DropTable(
                name: "DocenteCurso");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "PensionEscolar");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Boletin");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Acudiente");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
