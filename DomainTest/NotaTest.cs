using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class NotaTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcularPromedioCorrecto()
        {
            Nota nota = new Nota(
                4f,
                2.5f,
                3.0f,
                3.8f
            );
            Assert.AreEqual(nota.PromedioNota,(4f + 2.5f + 3.0f + 3.8f)/4f);
        }

        [Test]
        public void ValidarDatosNotasCorrectos()
        {
            Nota nota = new Nota(
                -4f,
                2.5f,
                3.0f,
                3.8f
            );
            Assert.AreEqual(nota.IsNotaValida(), true);
        }
    }
}
