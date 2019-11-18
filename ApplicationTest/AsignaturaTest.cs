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
        ColegioContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ColegioContext>().UseInMemoryDatabase("ColegioDBT").Options;
            _context = new ColegioContext(optionsInMemory);
        }

        [Test]
        public void RegistroExitosoAsignatura()
        {
            RegistrarAsignaturaRequest request = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service = new RegistrarAsignaturaService(new UnitOfWork(_context));
            var response = service.Ejecutar(request);
            Assert.AreEqual("Se registro correctamente la asignatura Español", response.Mensaje);
        }

        [Test]
        public void RegistroExitosoDocentesAsignatura()
        {
            RegistrarAsignaturaRequest request = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1001,
                NombreAsignatura = "Español"
            };
            RegistrarAsignaturaService service = new RegistrarAsignaturaService(new UnitOfWork(_context));
            service.Ejecutar(request);

            RegistrarAsignaturaRequest requestDos = new RegistrarAsignaturaRequest
            {
                CodigoAsignatura = 1002,
                NombreAsignatura = "Ingles"
            };
            RegistrarAsignaturaService serviceDos = new RegistrarAsignaturaService(new UnitOfWork(_context));
            service.Ejecutar(requestDos);

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
            RegistrarDocenteService serviceDocente = new RegistrarDocenteService(new UnitOfWork(_context));
            serviceDocente.Ejecutar(requestRegistrarDocente);



            List<int> listaAsignaturas = new List<int>();
            listaAsignaturas.Add(1001);
            listaAsignaturas.Add(1002);

            AsignarDocenteAsignaturaRequest requestAsignar = new AsignarDocenteAsignaturaRequest
            {
                ListaCodigosAsignaturas = listaAsignaturas,
                NumeroIdentificacion = 1065842658
            };
            AsignarDocenteAsignaturaService serviceAsignarDocente = new AsignarDocenteAsignaturaService(new UnitOfWork(_context));
            var response = serviceAsignarDocente.Ejecutar(requestAsignar);
            Assert.AreEqual("Las asignaturas, se han asignado al docente Richard Sanguino", response.Mensaje);
        }
    }
}