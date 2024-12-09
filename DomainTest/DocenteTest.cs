using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class DocenteTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidarAñosDeExperiencia()
        {
            Docente docente = new Docente(
                "C.C",
                1065842658,
                "Richard",
                "Andres",
                "Sanguino",
                "Ramirez",
                "Calle 31#28-17",
                3154177696,
                'M',
                21,
                2,
                1,
                "richard.3"
                );
            Assert.AreEqual(Docente.IsValidarAñosExperiencia(docente.AñosExperiencia),false);
        }

        [Test]
        public void ValidarEstandarCorreo()
        {
            Docente docente = new Docente(
                "C.C",
                1065842658,
                "Richard",
                "Andres",
                "Sanguino",
                "Ramirez",
                "Calle 31#28-17",
                3154177696,
                'M',
                21,
                2,
                1,
                "richard3"
                );
            Assert.AreEqual("richard3@ovf.com",docente.CorreoElectronico);
        }
    }
}
