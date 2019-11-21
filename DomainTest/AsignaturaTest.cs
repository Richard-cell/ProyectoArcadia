using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class AsignaturaTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ValidarRegistroDocentes() {
            Asignatura asignatura = new Asignatura(
                1001,
                "Español"
            );

            Docente docente1 = new Docente(
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
                "richard.3@gmail.com"
                );
            Docente docente2 = new Docente(
                "C.C",
                1065842657,
                "Anuar",
                "Andres",
                "Sanguino",
                "Ramirez",
                "Calle 31#28-17",
                3154177696,
                'M',
                21,
                2,
                1,
                "anuar.sanguino@gmail.com"
                );

            DocenteAsignatura docenteAnuar = new DocenteAsignatura(docente2,asignatura);
            DocenteAsignatura docenteRichard = new DocenteAsignatura(docente1,asignatura);

            asignatura.IsAlmacenarDocentes(docenteAnuar);
            asignatura.IsAlmacenarDocentes(docenteRichard);

            Assert.AreEqual(asignatura.ListaDocenteAsignaturas[0].Docente.PrimerNombre,"Anuar");
        }
    }
}
