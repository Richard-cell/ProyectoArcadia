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
            representanteLegal = new Acudiente(
                "Madre",
                "C.C",
                1065842658,
                "Alba",
                "Nerina",
                "Ramirez",
                "Gil",
                "Calle 31#28-17",
                3154177696,
                'F',
                1,
                "aldanerina@gmail.com"
                );

            pensionEscolar = new PensionEscolar(
                9019,
                new DateTime(2019,05,05)
                );

            listaNotas = new List<Nota>();
            Nota notaUno = new Nota(1001, 4f, 3f, 2.5f, 2.8f, new Asignatura(2001, "Español"));
            Nota notaDos = new Nota(1002, 5f, 3f, 2.5f, 3.8f, new Asignatura(2001, "Español"));
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
                representanteLegal,
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
                representanteLegal,
                'M',
                "anuarsanguino@gmail.com",
                pensionEscolar
                );
            estudiante.IsAlmacenarNota(listaNotas);
            Assert.AreEqual(estudiante.ListaNotas[0].PromedioNota,3.075f);
        }
    }
}
