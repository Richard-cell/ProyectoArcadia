using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarEstudianteResponse Ejecutar(ModificarEstudianteRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Id == request.DocumentoId);
            if (estudiante != null)
            {
                estudiante.PrimerNombre = request.PrimerNombreEstudiante;
                estudiante.SegundoNombre = request.SegundoNombreEstudiante;
                estudiante.PrimerApellido = request.PrimerApellidoEstudiante;
                estudiante.SegundoApellido = request.SegundoApellidoEstudiante;
                estudiante.Direccion = request.DireccionEstudiante;
                estudiante.Telefono = request.TelefonoEstudiante;
                estudiante.RH = request.RHEstudiante;
                estudiante.NumeroHermanos = request.NumeroHermanosEstudiante;
                estudiante.SeguroSocial = request.SeguroSocialEstudiante;
                estudiante.EstratoSocial = request.EstratoSocialEstudiante;
                estudiante.PuntajeSisben = request.PuntajeSisbenEstudiante;
                estudiante.CorreoElectronico = request.CorreoElectronicoEstudiante;

                _unitOfWork.EstudianteRepository.Edit(estudiante);
                _unitOfWork.Commit();
                return new ModificarEstudianteResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
            }
            else
            {
                return new ModificarEstudianteResponse { Mensaje = $"El número de documento no existe" };
            }
        }
    }

    public class ModificarEstudianteRequest
    {
        public int DocumentoId { get; set; }
        public string PrimerNombreEstudiante { get; set; }
        public string SegundoNombreEstudiante { get; set; }
        public string PrimerApellidoEstudiante { get; set; }
        public string SegundoApellidoEstudiante { get; set; }
        public string DireccionEstudiante { get; set; }
        public long TelefonoEstudiante { get; set; }
        public string RHEstudiante { get; set; }
        public int NumeroHermanosEstudiante { get; set; }
        public string SeguroSocialEstudiante { get; set; }
        public int EstratoSocialEstudiante { get; set; }
        public float PuntajeSisbenEstudiante { get; set; }
        public string CorreoElectronicoEstudiante { get; set; }
    }

    public class ModificarEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}