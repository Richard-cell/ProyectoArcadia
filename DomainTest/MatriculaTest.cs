using Domain.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTest
{
    public class MatriculaTest
    {
        Acudiente representanteLegal;
        Estudiante estudiante;
        PensionEscolar pensionEscolar;
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
                'F'
                );

            pensionEscolar = new PensionEscolar(
                9019,
                new DateTime(2019, 03, 05)
                );

            estudiante = new Estudiante(
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
                pensionEscolar
                );
        }

        [Test]
        public void RegistroExitosoEstudianteEnMatricula()
        {
            Matricula matricula = new Matricula(
                1212,
                new DateTime(2019,03,05),
                estudiante,
                representanteLegal,
                8,
                "Activa"
                );

            Assert.AreEqual(matricula.Estudiante.NumeroIdentificacion, 1003345637);
        }

        [Test]
        public void ValidarNumeroArchivosCorrecto()
        {
            Matricula matricula = new Matricula(
                1212,
                new DateTime(2019, 03, 05),
                estudiante,
                representanteLegal,
                8,
                "Activa"
                );

            Assert.AreEqual(matricula.NumeroDocumentosAdjuntados, 8);
        }
    }
}
