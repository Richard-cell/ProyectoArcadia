using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class EstudianteTest
    {
        Acudiente representanteLegal;
        PensionEscolar pensionEscolar;
        List<Nota> listaNotas;

        [SetUp]
        public void Setup()
        {
            pensionEscolar = new PensionEscolar(
                9019,
                new DateTime(2019,05,05)
                );
            Asignatura asignatura = new Asignatura(101, "calculo");
            Asignatura asignatura2 = new Asignatura(102, "español");
            
            listaNotas = new List<Nota>();
            Nota notaUno = new Nota(1001, asignatura, 4f, 3f, 2.5f, 2.8f);
            Nota notaDos = new Nota(1002, asignatura2, 5f, 3f, 2.5f, 3.8f);
            listaNotas.Add(notaUno);
            listaNotas.Add(notaDos);
        }

        [Test]
        public void RegistroExitosoNotas()
        {
            Estudiante estudiante = new Estudiante(
                "TI",
                1003345637,
                "Anuar",
                "Jose",
                "Sanguino",
                "Ramirez",
                "Calle 31#28-17",
                3154177696,
                "Valledupar",
                new DateTime(1998, 08, 12),
                "O+",
                2,
                2,
                "SI",
                2,
                32.7f,
                'M',
                "anuarsanguino@gmail.com",
                pensionEscolar
                );
            estudiante.IsAlmacenarNota(listaNotas);
            Assert.AreEqual(estudiante.ListaNotas.Count, 2);
        }

        [Test]
        public void ValidarPromedioNotas()
        {
            Estudiante estudiante = new Estudiante(
                "TI",
                1003345637,
                "Anuar",
                "Jose",
                "Sanguino",
                "Ramirez",
                "Calle 31#28-17",
                3154177696,
                "Valledupar",
                new DateTime(1998,08,12),
                "O+",
                2,
                2,
                "SI",
                2,
                32.7f,
                'M',
                "anuarsanguino@gmail.com",
                pensionEscolar
                );
            estudiante.IsAlmacenarNota(listaNotas);
            Assert.AreEqual(estudiante.ListaNotas[0].PromedioNota,3.075f);
        }
    }
}
