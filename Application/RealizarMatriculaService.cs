using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RealizarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public RealizarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RealizarMatriculaResponse Ejecutar(RealizarMatriculaRequest request)
        {
           Matricula matricula = _unitOfWork.MatriculaRepository.FindFirstOrDefault(t => t.Id == request.CodigoMatricula);
            if (matricula == null)
            {
                if (Matricula.IsValidarNumeroDocumentos(request.NumeroDocumentosAdjuntados)) {
                    matricula = new Matricula(
                        request.CodigoMatricula,
                        request.FechaMatricula,
                        AlmacenarEstudiante(request),
                        request.NumeroDocumentosAdjuntados,
                        request.EstadoMatricula
                        );
                    _unitOfWork.MatriculaRepository.Add(matricula);
                    _unitOfWork.Commit();
                    return new RealizarMatriculaResponse() { Mensaje = $"Se creó con exito la matricula {request.CodigoMatricula}" };
                }
                else
                {
                    return new RealizarMatriculaResponse() { Mensaje = $"Debe adjuntar los 8 documentos requeridos" };
                }
                  
            }
            else
            {
                return new RealizarMatriculaResponse() { Mensaje = $"El estudiante {request.PrimerNombreEstudiante} {request.PrimerApellidoEstudiante} ya se encuentra matriculado" };
            }
        }

        private Estudiante AlmacenarEstudiante(RealizarMatriculaRequest request)
        {
            return new Estudiante(
                request.TipoDocumentoEstudiante,
                request.NumeroIdentificacionEstudiante,
                request.PrimerNombreEstudiante,
                request.SegundoNombreEstudiante,
                request.PrimerApellidoEstudiante,
                request.SegundoApellidoEstudiante,
                request.DireccionEstudiante,
                request.TelefonoEstudiante,
                request.LugarNacimientoEstudiante,
                request.FechaNacimientoEstudiante,
                request.RHEstudiante,
                request.NumeroHermanosEstudiante,
                request.LugarEntreHermanosEstudiante,
                request.SeguroSocialEstudiante,
                request.EstratoSocialEstudiante,
                request.PuntajeSisbenEstudiante,
                request.SexoEstudiante,
                request.CorreoElectronicoEstudiante,
                AlmacenarPensionEscolar(ConcatenarNumeros(request.NumeroIdentificacionEstudiante),request.FechaMatricula)
                );
        }

        private Acudiente AlmacenarAcudiente(RealizarMatriculaRequest request) {
            return new Acudiente(
                request.Parentezco,
                request.TipoDocumentoAcudiente,
                request.NumeroIdentificacionAcudiente,
                request.PrimerNombreAcudiente,
                request.SegundoNombreAcudiente,
                request.PrimerApellidoAcudiente,
                request.SegundoApellidoAcudiente,
                request.DireccionAcudiente,
                request.TelefonoAcudiente,
                request.SexoAcudiente,
                request.EstratoSocialAcudiente,
                request.CorreoElectronicoAcudiente
                );
        }

        private PensionEscolar AlmacenarPensionEscolar(long codigoPensionEscolar, DateTime fechaInicioPension)
        {
            return new PensionEscolar(
                codigoPensionEscolar,
                fechaInicioPension
                );
        }

        private long ConcatenarNumeros(long numero) {
            string numeroUno = numero.ToString();
            string numeroFinal = numeroUno + "2019";
            return long.Parse(numeroFinal);
        }
    }

    public class RealizarMatriculaRequest
    {
        public int CodigoMatricula { get; set; }
        public DateTime FechaMatricula { get; set; }
        public long NumeroIdentificacionEstudiante { get;set; }
        public string TipoDocumentoEstudiante { get; set; }
        public string PrimerNombreEstudiante { get; set; }
        public string SegundoNombreEstudiante { get;set; }
        public string PrimerApellidoEstudiante { get; set; }
        public string SegundoApellidoEstudiante { get; set; }
        public string DireccionEstudiante { get; set; }
        public long TelefonoEstudiante { get; set; }
        public char SexoEstudiante { get; set; }
        public int EstratoSocialEstudiante { get; set; }
        public string CorreoElectronicoEstudiante { get; set; }
        public string LugarNacimientoEstudiante { get; set; }
        public DateTime FechaNacimientoEstudiante { get; set; }
        public string RHEstudiante { get; set; }
        public int NumeroHermanosEstudiante { get; set; }
        public int LugarEntreHermanosEstudiante { get; set; }
        public string SeguroSocialEstudiante { get; set; }
        public float PuntajeSisbenEstudiante { get; set; }
        public long NumeroIdentificacionAcudiente { get; set; }
        public string TipoDocumentoAcudiente { get; set; }
        public string PrimerNombreAcudiente { get; set; }
        public string SegundoNombreAcudiente { get; set; }
        public string PrimerApellidoAcudiente { get; set; }
        public string SegundoApellidoAcudiente { get; set; }
        public string DireccionAcudiente { get; set; }
        public long TelefonoAcudiente { get; set; }
        public char SexoAcudiente { get; set; }
        public int EstratoSocialAcudiente { get; set; }
        public string CorreoElectronicoAcudiente { get;  set; }
        public string Parentezco { get; set; }
        public int NumeroDocumentosAdjuntados { get;  set; }
        public string EstadoMatricula { get;  set; }
    }

    public class RealizarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }
}
