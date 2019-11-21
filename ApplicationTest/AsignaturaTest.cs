using Application;
using Infraestructure.Base;
using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace ApplicationTest
{
    public class Tests
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
        public void RegistroExitosoAsignatura()
        {
            RegistrarAsignaturaRequest request = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service = new RegistrarAsignaturaService(new UnitOfWork(_contextInMemory));
            var response = service.Ejecutar(request);
            Assert.AreEqual("Se registro correctamente la asignatura Español", response.Mensaje);
        }

        [Test]
        public void RegistroExitosoDocentesAsignatura()
        {
            RegistrarAsignaturaRequest requestRegistrarAsignatura = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service = new RegistrarAsignaturaService(new UnitOfWork(_contextInBD));
            service.Ejecutar(requestRegistrarAsignatura);

            RegistrarDocenteRequest requestRegistrarDocente = new RegistrarDocenteRequest
            {
                TipoDocumento="CC",
                DocumentoIdentidad = 1065842658,
                PrimerNombre = "Richard",
                SegundoNombre="Andres",
                PrimerApellido = "Sanguino",
                SegundoApellido ="Ramirez",
                Direccion="Calle",
                Telefono = 54242,
                Sexo='M',
                Edad = 22,
                AñosExperiencia = 3,
                Estrato = 1,
                Email = "ssss"
            };
            RegistrarDocenteService serviceDocente = new RegistrarDocenteService(new UnitOfWork(_contextInBD));
            serviceDocente.Ejecutar(requestRegistrarDocente);

            AsignarDocenteAsignaturaRequest requestAsignar = new AsignarDocenteAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NumeroIdentificacion = 1065842658
            };
            AsignarDocenteAsignaturaService serviceAsignarDocente = new AsignarDocenteAsignaturaService(new UnitOfWork(_contextInBD));
            var response = serviceAsignarDocente.Ejecutar(requestAsignar);
            Assert.AreEqual("Se le asigno al docente Richard correctamente la asignatura de Español", response.Mensaje);
        }
    }
}