using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class BoletinTest
    {
        List<Nota> listaNotas;

        [SetUp]
        public void Setup()
        {
            listaNotas = new List<Nota>();
            Nota notaUno = new Nota(4f,3f,2.5f,2.8f);
            Nota notaDos = new Nota(5f,3f,2.5f,3.8f);
            listaNotas.Add(notaUno);
            listaNotas.Add(notaDos);
        }

        [Test]
        public void RegistroExitosoNotas()
        {
            Boletin boletin = new Boletin(3001,listaNotas);
            Assert.AreEqual(boletin.ListaNotas.Count,2);
        }
    }
}
