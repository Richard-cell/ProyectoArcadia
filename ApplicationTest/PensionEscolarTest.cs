using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Application;
using Infraestructure.Base;

namespace ApplicationTest
{
    public class PensionEscolarTest
    {
        ColegioContext _contextInMemory;
        ColegioContext _contextInBD;

        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<ColegioContext>()
             .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = ColegioDB; Trusted_Connection = True; MultipleActiveResultSets = true")
             .Options;
            var optionsInMemory = new DbContextOptionsBuilder<ColegioContext>().UseInMemoryDatabase("ColegioDBT").Options;
            _contextInMemory = new ColegioContext(optionsInMemory);
            _contextInBD = new ColegioContext(optionsSqlServer);
        }

        [Test]
        public void PagarCuotaPension()
        {
            RealizarMatriculaRequest request = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 98081212260,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Richard",
                SegundoNombreEstudiante = "Andres",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842658,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service.Ejecutar(request);

            PagarCuotaPensionRequest requestPagarCuota = new PagarCuotaPensionRequest
            {
                NumeroIdentificacionEstudiante = 98081212260,
                FechaPagoCuota = new DateTime(2019, 05, 05)
            };
            PagarCuotaPensionService servicePagarCuota = new PagarCuotaPensionService(new UnitOfWork(_contextInMemory));
            var response = servicePagarCuota.Ejecutar(requestPagarCuota);
            Assert.AreEqual("Se ha pagado la cuota del mes 0 correctamente, con un interes del 0", response.Mensaje);
        }

        [Test]
        public void ConsultarPagoPensionExitoso()
        {
            RealizarMatriculaRequest request = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019, 05, 05),
                NumeroIdentificacionEstudiante = 98081212260,
                TipoDocumentoEstudiante = "TI",
                PrimerNombreEstudiante = "Richard",
                SegundoNombreEstudiante = "Andres",
                PrimerApellidoEstudiante = "Sanguino",
                SegundoApellidoEstudiante = "Ramirez",
                DireccionEstudiante = "Calle 31#28-17",
                TelefonoEstudiante = 3101234567,
                SexoEstudiante = 'M',
                EstratoSocialEstudiante = 1,
                CorreoElectronicoEstudiante = "No tiene",
                LugarNacimientoEstudiante = "Valledupar",
                FechaNacimientoEstudiante = new DateTime(1998, 12, 08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842658,
                TipoDocumentoAcudiente = "CC",
                PrimerNombreAcudiente = "Richard",
                SegundoNombreAcudiente = "Jose",
                PrimerApellidoAcudiente = "Sanguino",
                SegundoApellidoAcudiente = "Sanguino",
                DireccionAcudiente = "Calle 31#28-17",
                TelefonoAcudiente = 3154177696,
                SexoAcudiente = 'M',
                EstratoSocialAcudiente = 1,
                CorreoElectronicoAcudiente = "richard3.sanguino",
                Parentezco = "Padre",
                NumeroDocumentosAdjuntados = 8,
                EstadoMatricula = "Activa"
            };

            RealizarMatriculaService service = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            service.Ejecutar(request);

            PagarCuotaPensionRequest requestPagarCuota = new PagarCuotaPensionRequest
            {
                NumeroIdentificacionEstudiante = 98081212260,
                FechaPagoCuota = new DateTime(2019, 05, 05)
            };
            PagarCuotaPensionService servicePagarCuota = new PagarCuotaPensionService(new UnitOfWork(_contextInMemory));
            servicePagarCuota.Ejecutar(requestPagarCuota);

            PagarCuotaPensionRequest requestPagarCuotaUno = new PagarCuotaPensionRequest
            {
                NumeroIdentificacionEstudiante = 98081212260,
                FechaPagoCuota = new DateTime(2019, 06,06)
            };
            PagarCuotaPensionService servicePagarCuotaUno = new PagarCuotaPensionService(new UnitOfWork(_contextInMemory));
            servicePagarCuotaUno.Ejecutar(requestPagarCuotaUno);

            ConsultarCuotaRequest requestConsultarCuota = new ConsultarCuotaRequest
            {
                NumeroIdentificacionEstudiante = 98081212260,
                NumeroCuotaAConsultar = 1
            };
            ConsultarCuotaService serviceConsultarCuota = new ConsultarCuotaService(new UnitOfWork(_contextInMemory));
            var response = serviceConsultarCuota.Ejecutar(requestConsultarCuota);
            Assert.AreEqual("Cuota Mes: 1" +
                    $"Fecha Pago Cuota: 6/06/2019 12:00:00 a. m." +
                    $"Fecha Limite Pago Cuota: 5/06/2019 12:00:00 a. m." +
                    $"Valor Cuota:60000" +
                    $"Valor Total a pagar:69000" +
                    $"Estado Cuota: Pagado", response.Mensaje);
        }
    }
}
