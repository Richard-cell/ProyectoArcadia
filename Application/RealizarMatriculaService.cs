using Domain.Contracts;
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

            if (request == null)
            {

                
                _unitOfWork.Commit();
                return new RealizarMatriculaResponse() { Mensaje = $"Se creó con exito la matricula para el documento {request.DocumentoIdentidad}" };
            }
            else
            {
                return new RealizarMatriculaResponse() { Mensaje = $"El número de documento ya exite" };
            }
        }
    }

    public class RealizarMatriculaRequest
    {
        public string DocumentoIdentidad { get; set; }
        public int GradoAspirante { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreEstudiante { get; set; }
        public string LugarFechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public int Telefono { get; set; }
        public string RH { get; set; }
        public char Sexo { get; set; }
        public int NumHermanos { get; set; }
        public int LugarEntreHermanos { get; set; }
        public string SeguroMedico { get; set; }
        public int Estrato { get; set; }
        public float PuntajeSisben { get; set; }
        public string Representante { get; set; }
        public string CedRepresentante { get; set; }
        public string DireccionRepresentante { get; set; }
        public string Parentesco { get; set; }
        public int TelefonoRepresentante { get; set; }
        public string NombrePadre { get; set; }
        public string CedPadre { get; set; }
        public string ProfesionPadre { get; set; }
        public string DireccionPadre { get; set; }
        public int TelefonoPadre { get; set; }
        public string NombreMadre { get; set; }
        public string CedMadre { get; set; }
        public string ProfesionMadre { get; set; }
        public string DireccionMadre { get; set; }
        public int TelefonoMadre { get; set; }
        public string EstadoMatricula { get; set; }
        public int NumDocumentosAdjuntos { get; set; }
    }

    public class RealizarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }
}
