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
            Asignatura asignatura = new Asignatura(101,"calculo");
            
            listaNotas = new List<Nota>();
            Nota notaUno = new Nota(1001,asignatura,4f, 3f, 2.5f, 2.8f);
            Nota notaDos = new Nota(1002,asignatura,5f, 3f, 2.5f, 3.8f);
            listaNotas.Add(notaUno);
            listaNotas.Add(notaDos);
        }

        [Test]
        public void RegistroExitosoNotas()
        {
            Boletin boletin = new Boletin(3001, listaNotas);
            Assert.AreEqual(boletin.ListaNotas.Count, 2);
        }
    }
}
