using Infraestructure.Contextos;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Application;
using System.Collections.Generic;
using System.Text;
using Infraestructure.Base;

namespace ApplicationTest
{
    public class MatriculaTest
    {
        ColegioContext _contextInMemory;
        ColegioContext _contextInBD;
        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<ColegioContext>().UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = ColegioDB; Trusted_Connection = True; MultipleActiveResultSets = true").Options;
            var optionsInMemory = new DbContextOptionsBuilder<ColegioContext>().UseInMemoryDatabase("ColegioDBT").Options;
            _contextInMemory = new ColegioContext(optionsInMemory);
            _contextInBD = new ColegioContext(optionsSqlServer);
        }

        [Test]
        public void RegistroExitosoMatricula()
        {
            RealizarMatriculaRequest request = new RealizarMatriculaRequest
            {
                CodigoMatricula = 1001,
                FechaMatricula = new DateTime(2019,05,05),
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
                FechaNacimientoEstudiante = new DateTime(1998,12,08),
                RHEstudiante = "O+",
                NumeroHermanosEstudiante = 3,
                LugarEntreHermanosEstudiante = 2,
                SeguroSocialEstudiante = "Si tiene",
                PuntajeSisbenEstudiante = 12.5f,
                NumeroIdentificacionAcudiente = 106842658,
                TipoDocumentoAcudiente  = "CC",
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
            var response = service.Ejecutar(request);
            Assert.AreEqual("Se creó con exito la matricula 1001",response.Mensaje);
        }

        [Test]
        public void CancelarMatriculaExitoso()
        {
            RealizarMatriculaRequest requestUno = new RealizarMatriculaRequest
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

            RealizarMatriculaService serviceUno = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            serviceUno.Ejecutar(requestUno);

            CancelarMatriculaRequest request = new CancelarMatriculaRequest
            {
                CodMatricula = 1001,
                FechaCancelacion = new DateTime(2019, 05, 06),
                MotivoCancelacion = "Tipo Economico"
            };
            CancelarMatriculaService service = new CancelarMatriculaService(new UnitOfWork(_contextInMemory));
            var response = service.Ejecutar(request);
            Assert.AreEqual("Se cancelo la matricula con el codigo 1001",response.Mensaje);
        }

        [Test]
        public void ValidarMotivoDeCancelacionMatricula()
        {
            RealizarMatriculaRequest requestUno = new RealizarMatriculaRequest
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

            RealizarMatriculaService serviceUno = new RealizarMatriculaService(new UnitOfWork(_contextInMemory));
            serviceUno.Ejecutar(requestUno);

            CancelarMatriculaRequest request = new CancelarMatriculaRequest
            {
                CodMatricula = 1001,
                FechaCancelacion = new DateTime(2019, 05, 06),
                MotivoCancelacion = ""
            };
            CancelarMatriculaService service = new CancelarMatriculaService(new UnitOfWork(_contextInMemory));
            var response = service.Ejecutar(request);
            Assert.AreEqual("Indique el motivo de cancelacion de la matricula", response.Mensaje);
        }
    }
}
