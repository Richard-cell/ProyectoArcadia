using Application;
using Infraestructure.Base;
using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

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
    }
}