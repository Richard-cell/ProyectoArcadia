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
    public class CursoTest
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
        public void RegistroCursoExitoso()
        {
            RegistrarCursoRequest request = new RegistrarCursoRequest
            {
                CodigoCurso = 601,
                Grado = 6
            };
            RegistrarCursoService service = new RegistrarCursoService(new UnitOfWork(_contextInMemory));
            var response = service.Ejecutar(request);
            Assert.AreEqual("Se registro correctamente el curso 601", response.Mensaje);
        }

        [Test]
        public void AsignarDocenteACursoExitoso()
        {
            RegistrarCursoRequest requestCurso = new RegistrarCursoRequest
            {
                CodigoCurso = 601,
                Grado = 6
            };
            RegistrarCursoService serviceCurso = new RegistrarCursoService(new UnitOfWork(_contextInMemory));
            serviceCurso.Ejecutar(requestCurso);

            RegistrarAsignaturaRequest requestAsignatura = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService serviceAsignatura = new RegistrarAsignaturaService(new UnitOfWork(_contextInMemory));
            serviceAsignatura.Ejecutar(requestAsignatura);

            RegistrarDocenteRequest requestDocente = new RegistrarDocenteRequest
            {
                TipoDocumento = "CC",
                DocumentoIdentidad = 1065842658,
                PrimerNombre = "Richard",
                SegundoNombre = "Andres",
                PrimerApellido = "Sanguino",
                SegundoApellido = "Ramirez",
                Direccion = "Calle",
                Telefono = 54242,
                Sexo = 'M',
                Edad = 22,
                AñosExperiencia = 3,
                Estrato = 1,
                Email = "ssss"
            };
            RegistrarDocenteService serviceDocente = new RegistrarDocenteService(new UnitOfWork(_contextInMemory));
            serviceDocente.Ejecutar(requestDocente);

            AsignarDocenteACursoRequest requestAsignarDocenteACurso = new AsignarDocenteACursoRequest
            {
                CodigoAsignatura = 1001,
                CodigoCurso = 601,
                NumeroIdentificacionDocente = 1065842658
            };
            AsignarDocenteACursoService serviceAsignarDocenteACurso = new AsignarDocenteACursoService(new UnitOfWork(_contextInMemory));
            var response = serviceAsignarDocenteACurso.Ejecutar(requestAsignarDocenteACurso);
            Assert.AreEqual("Se ha asignado correctamente el docente 1065842658 al curso 601", response.Mensaje);
        }
    }
}
