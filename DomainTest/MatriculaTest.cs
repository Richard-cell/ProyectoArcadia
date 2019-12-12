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

            pensionEscolar = new PensionEscolar(
                9019,
                new DateTime(2019, 03, 05)
                );

            representanteLegal = new Acudiente(
                "Padre",
                "C.C",
                1065234563,
                "Alba",
                "Ramirez",
                "Ramirez",
                "Gil",
                "Calle 31#24-12",
                3154787847,
                'F',
                2,
                "alba@gmail.com"
                );

            estudiante = new Estudiante(
                representanteLegal.Id,
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
        }

        [Test]
        public void RegistroExitosoEstudianteEnMatricula()
        {
            Matricula matricula = new Matricula(
                1212,
                new DateTime(2019,03,05),
                estudiante,
                8,
                "Activa"
                );

            Assert.AreEqual(matricula.Estudiante.Id, 1003345637);
        }

        [Test]
        public void ValidarNumeroArchivosCorrecto()
        {
            Matricula matricula = new Matricula(
                1212,
                new DateTime(2019, 03, 05),
                estudiante,
                8,
                "Activa"
                );

            Assert.AreEqual(matricula.NumeroDocumentosAdjuntados, 8);
        }
    }
}
