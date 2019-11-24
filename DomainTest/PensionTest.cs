using Domain.Entidades;
using NUnit.Framework;
using System;

namespace DomainTest
{
    public class PensionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegistroCorrectoCuotas()
        {
            PensionEscolar pensionEscolar = new PensionEscolar(
                1001,
                new DateTime(2019, 05, 05)
            );
            Assert.AreEqual(pensionEscolar.ListaCuotas.Count, 10);
        }

        [Test]
        public void ValidarPagoCuotaSinInteres()
        {
            PensionEscolar pensionEscolar = new PensionEscolar(
                1001,
                new DateTime(2019,05,05)
            );
            pensionEscolar.ListaCuotas[1].IsRealizarPagoCuota(new DateTime(2019,05,06));
            Assert.AreEqual(pensionEscolar.ListaCuotas[1].ValorTotalAPagar,60000f);
        }

        [Test]
        public void ValidarPagoCuotaConInteres()
        {
            PensionEscolar pensionEscolar = new PensionEscolar(
                1001,
                new DateTime(2019, 05, 05)
                );
            pensionEscolar.ListaCuotas[1].IsRealizarPagoCuota(new DateTime(2019, 06, 10));
            Assert.AreEqual(pensionEscolar.ListaCuotas[1].ValorTotalAPagar, 81000f);
        }

        [Test]
        public void ValidarLimitePagoCuota()
        {
            PensionEscolar pensionEscolar = new PensionEscolar(
                1001,
                new DateTime(2019, 05, 05)
                );
            Assert.AreEqual(pensionEscolar.ListaCuotas[2].FechaLimitePagoCuota, new DateTime(2019,07,05));
        }
    }
}