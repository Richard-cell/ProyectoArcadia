using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AsignarEstudianteACursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public AsignarEstudianteACursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AsignarEstudianteACursoResponse Ejecutar(AsignarEstudianteACursoRequest request)
        {
            Curso curso = _unitOfWork.CursoRepository.FindFirstOrDefault(x=>x.Id==request.CodigoCurso);
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(x=>x.Id==request.NumeroIdentificacionEstudiante);
            
            if (estudiante!=null)
            {
                curso.IsAlmacenarEstudiante(estudiante);
                _unitOfWork.CursoRepository.Edit(curso);
                _unitOfWork.Commit();
                return new AsignarEstudianteACursoResponse { Mensaje = $"Se ha asignado correctamente el estudiante {estudiante.PrimerNombre} {estudiante.PrimerApellido} al curso {curso.Id}" };
            }
            else
            {
                return new AsignarEstudianteACursoResponse { Mensaje = $"El estudiante {estudiante.PrimerNombre} {estudiante.PrimerApellido} ya se encuentra registrado en el curso {estudiante.CursoId}" };
            }
            
        }
    }

    public class AsignarEstudianteACursoRequest
    {
        public long NumeroIdentificacionEstudiante { get; set; }
        public long CodigoCurso { get; set; }
    }

    public class AsignarEstudianteACursoResponse
    {
        public string Mensaje { get; set; }
    }
}
