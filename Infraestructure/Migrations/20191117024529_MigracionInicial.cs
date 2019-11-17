using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false),
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
                    Id = table.Column<int>(nullable: false),
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
                name: "PensionEscolar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FechaInicioPension = table.Column<DateTime>(nullable: false),
                    ValorPension = table.Column<float>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionEscolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocenteCurso",
                columns: table => new
                {
                    DocenteId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DocenteId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteCurso", x => new { x.DocenteId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocenteCurso_Docente_DocenteId1",
                        column: x => x.DocenteId1,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Parentezco = table.Column<string>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: false),
                    MatriculaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acudiente_Matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesCuota = table.Column<int>(nullable: false),
                    FechaPagoCuota = table.Column<DateTime>(nullable: false),
                    FechaLimitePagoCuota = table.Column<DateTime>(nullable: false),
                    ValorCuota = table.Column<float>(nullable: false),
                    ValorTotalAPagar = table.Column<float>(nullable: false),
                    EstadoCuota = table.Column<string>(nullable: true),
                    PensionEscolarId = table.Column<int>(nullable: false)
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
                    MatriculaId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    RepresentanteLegalId = table.Column<long>(nullable: true),
                    PensionEscolarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiante_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiante_Matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiante_PensionEscolar_PensionEscolarId",
                        column: x => x.PensionEscolarId,
                        principalTable: "PensionEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiante_Acudiente_RepresentanteLegalId",
                        column: x => x.RepresentanteLegalId,
                        principalTable: "Acudiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NotaPrimerPeriodo = table.Column<float>(nullable: false),
                    NotaSegundoPeriodo = table.Column<float>(nullable: false),
                    NotaTercerPeriodo = table.Column<float>(nullable: false),
                    NotaCuartoPeriodo = table.Column<float>(nullable: false),
                    PromedioNota = table.Column<float>(nullable: false),
                    BoletinId = table.Column<int>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    EstudianteId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Boletin_BoletinId",
                        column: x => x.BoletinId,
                        principalTable: "Boletin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Estudiante_EstudianteId1",
                        column: x => x.EstudianteId1,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NombreAsignatura = table.Column<string>(nullable: true),
                    NotaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignatura_Nota_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Nota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteAsignatura",
                columns: table => new
                {
                    DocenteId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false),
                    DocenteId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteAsignatura", x => new { x.AsignaturaId, x.DocenteId });
                    table.ForeignKey(
                        name: "FK_DocenteAsignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocenteAsignatura_Docente_DocenteId1",
                        column: x => x.DocenteId1,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acudiente_MatriculaId",
                table: "Acudiente",
                column: "MatriculaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_NotaId",
                table: "Asignatura",
                column: "NotaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_PensionEscolarId",
                table: "Cuota",
                column: "PensionEscolarId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteAsignatura_DocenteId1",
                table: "DocenteAsignatura",
                column: "DocenteId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_CursoId",
                table: "DocenteCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteCurso_DocenteId1",
                table: "DocenteCurso",
                column: "DocenteId1");

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
                name: "IX_Estudiante_PensionEscolarId",
                table: "Estudiante",
                column: "PensionEscolarId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_RepresentanteLegalId",
                table: "Estudiante",
                column: "RepresentanteLegalId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_BoletinId",
                table: "Nota",
                column: "BoletinId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EstudianteId1",
                table: "Nota",
                column: "EstudianteId1");
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
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Boletin");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "PensionEscolar");

            migrationBuilder.DropTable(
                name: "Acudiente");

            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
