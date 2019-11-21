using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Application;
using System;
using System.Collections.Generic;
using System.Text;
using Infraestructure.Base;

namespace ApplicationTest
{
    public class DocenteTest
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
        public void RegistroExitosoDocente()
        {
            RegistrarDocenteRequest requestRegistrarDocente = new RegistrarDocenteRequest
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
            RegistrarDocenteService serviceDocente = new RegistrarDocenteService(new UnitOfWork(_contextInBD));
            var response = serviceDocente.Ejecutar(requestRegistrarDocente);
            Assert.AreEqual("Se registro correctamente al docente 1065842658",response.Mensaje);
        }
    }
}
