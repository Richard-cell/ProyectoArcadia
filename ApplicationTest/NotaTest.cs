using Application;
using Infraestructure.Base;
using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationTest
{
    public class NotaTest
    {
        ColegioContext _contextInMemory;
        ColegioContext _contextInBD;

        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<ColegioContext>()
             .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = ColegioDB; Trusted_Connection = True; MultipleActiveResultSets = true")
             .Options;
            var optionsInMemory = new DbContextOptionsBuilder<ColegioContext>().UseInMemoryDatabase("ColegioDBT").Options;
            _contextInMemory = new ColegioContext(optionsInMemory);
            _contextInBD = new ColegioContext(optionsSqlServer);
        }

        [Test]
        public void CrearRegistroNotaExitoso()
        {
            RegistrarCursoRequest request = new RegistrarCursoRequest
            {
                CodigoCurso = 601,
                Grado = 6
            };
            RegistrarCursoService service = new RegistrarCursoService(new UnitOfWork(_contextInMemory));
            service.Ejecutar(request);

            RealizarMatriculaRequest request2 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 98081212260,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Richard",
                SegundoNombreEstudiante = "Andres",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 1068426585,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service2 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service2.Ejecutar(request2);

            RealizarMatriculaRequest request3 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1002,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 1065842658,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Anuar",
                SegundoNombreEstudiante = "Jose",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 1068426585,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service3 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service3.Ejecutar(request3);

            RegistrarAsignaturaRequest request4 = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service4 = new RegistrarAsignaturaService(new UnitOfWork(_contextInMemory));
            service4.Ejecutar(request4);

            AsignarEstudianteACursoRequest requestAsignarEstudiante = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 98081212260
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante.Ejecutar(requestAsignarEstudiante);

            AsignarEstudianteACursoRequest requestAsignarEstudiante2 = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 1065842658
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante2 = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante2.Ejecutar(requestAsignarEstudiante2);

            CrearRegistroNotaEstudianteRequest requestUltimo = new CrearRegistroNotaEstudianteRequest
            {
                CodigoCurso = 601,
                CodigoAsignatura = 1001
            };
            CrearRegistroNotaEstudianteService serviceUltimo = new CrearRegistroNotaEstudianteService(new UnitOfWork(_contextInMemory));
            var response = serviceUltimo.Ejecutar(requestUltimo);
            Assert.AreEqual("Se han creado los registros de notas satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void ConusltarNotaExitoso()
        {
            RegistrarCursoRequest request = new RegistrarCursoRequest
            {
                CodigoCurso = 601,
                Grado = 6
            };
            RegistrarCursoService service = new RegistrarCursoService(new UnitOfWork(_contextInMemory));
            service.Ejecutar(request);

            RealizarMatriculaRequest request2 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 98081212260,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Richard",
                SegundoNombreEstudiante = "Andres",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842657,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service2 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service2.Ejecutar(request2);

            RealizarMatriculaRequest request3 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1002,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 1065842658,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Anuar",
                SegundoNombreEstudiante = "Jose",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842657,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service3 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service3.Ejecutar(request3);

            RegistrarAsignaturaRequest request4 = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service4 = new RegistrarAsignaturaService(new UnitOfWork(_contextInMemory));
            service4.Ejecutar(request4);

            AsignarEstudianteACursoRequest requestAsignarEstudiante = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 98081212260
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante.Ejecutar(requestAsignarEstudiante);

            AsignarEstudianteACursoRequest requestAsignarEstudiante2 = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 1065842658
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante2 = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante2.Ejecutar(requestAsignarEstudiante2);

            CrearRegistroNotaEstudianteRequest requestCrear = new CrearRegistroNotaEstudianteRequest
            {
                CodigoCurso = 601,
                CodigoAsignatura = 1001
            };
            CrearRegistroNotaEstudianteService serviceCrear = new CrearRegistroNotaEstudianteService(new UnitOfWork(_contextInMemory));
            serviceCrear.Ejecutar(requestCrear);

            ConsultarNotaRequest requestUltimo = new ConsultarNotaRequest
            {
                IdAsignaturaConsultar = 1001,
                DocEstudiante = 1065842658
            };
            ConsultarNotaService serviceUltimo = new ConsultarNotaService(new UnitOfWork(_contextInMemory));
            var response = serviceUltimo.Ejecutar(requestUltimo);
            Assert.AreEqual("Id nota: 10658426581001" +
                        $"asignatura: Español" +
                        $"Nota 1° periodo: 0" +
                        $"Nota 2° periodo: 0" +
                        $"Nota 3° periodo: 0" +
                        $"Nota 4° periodo: 0" +
                        $"Promedio de notas: 0", response.Mensaje);
        }

        [Test]
        public void ModificarNotaExitoso()
        {
            RegistrarCursoRequest request = new RegistrarCursoRequest
            {
                CodigoCurso = 601,
                Grado = 6
            };
            RegistrarCursoService service = new RegistrarCursoService(new UnitOfWork(_contextInMemory));
            service.Ejecutar(request);

            RealizarMatriculaRequest request2 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 98081212260,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Richard",
                SegundoNombreEstudiante = "Andres",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842657,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service2 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service2.Ejecutar(request2);

            RealizarMatriculaRequest request3 = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1002,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 1065842658,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Anuar",
                SegundoNombreEstudiante = "Jose",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842657,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service3 = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service3.Ejecutar(request3);

            RegistrarAsignaturaRequest request4 = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service4 = new RegistrarAsignaturaService(new UnitOfWork(_contextInMemory));
            service4.Ejecutar(request4);

            AsignarEstudianteACursoRequest requestAsignarEstudiante = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 98081212260
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante.Ejecutar(requestAsignarEstudiante);

            AsignarEstudianteACursoRequest requestAsignarEstudiante2 = new AsignarEstudianteACursoRequest
            {
                CodigoCurso = 601,
                NumeroIdentificacionEstudiante = 1065842658
            };
            AsignarEstudianteACursoService serviceAsignarEstudiante2 = new AsignarEstudianteACursoService(new UnitOfWork(_contextInMemory));
            serviceAsignarEstudiante2.Ejecutar(requestAsignarEstudiante2);

            CrearRegistroNotaEstudianteRequest requestCrear = new CrearRegistroNotaEstudianteRequest
            {
                CodigoCurso = 601,
                CodigoAsignatura = 1001
            };
            CrearRegistroNotaEstudianteService serviceCrear = new CrearRegistroNotaEstudianteService(new UnitOfWork(_contextInMemory));
            serviceCrear.Ejecutar(requestCrear);

            ModificarNotasRequest requestModificar = new ModificarNotasRequest { 
                NumeroIdentificacionEstudiante= 1065842658,
                CodigoAsignatura = 1001,
                NotaUno = 5.0f,
                NotaDos = 2.3f,
                NotaTres = 3.8f,
                NotaCuatro = 4.3f
            };
            ModificarNotasService serviceModificar = new ModificarNotasService(new UnitOfWork(_contextInMemory));
            var response = serviceModificar.Ejecutar(requestModificar);
            Assert.AreEqual("Se ha modificado las notas de la asignatura Español para el estudiante Richard", response.Mensaje);
        }
    }
}
