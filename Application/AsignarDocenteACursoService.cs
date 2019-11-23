using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AsignarDocenteACursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public AsignarDocenteACursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AsignarDocenteACursoResponse Ejecutar(AsignarDocenteACursoRequest request)
        {
            Curso curso = _unitOfWork.CursoRepository.FindFirstOrDefault(x=>x.Id == request.CodigoCurso);
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x=>x.Id==request.CodigoAsignatura);
            Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x => x.Id == request.NumeroIdentificacionDocente);

            if (!curso.IsValidarDocenteExistenteEnCurso(request.NumeroIdentificacionDocente))
            {
                if (!curso.IsValidarDocenteConMismaAsignatura(asignatura.Id))
                {
                    DocenteCurso docenteCurso = new DocenteCurso(docente,curso);
                    curso.IsAlmacenarDocentes(docenteCurso);
                    _unitOfWork.CursoRepository.Edit(curso);
                    _unitOfWork.Commit();
                    return new AsignarDocenteACursoResponse { Mensaje = $"Se ha asignado correctamente el docente {docente.Id} al curso {curso.Id}" };
                }
                else
                {
                    return new AsignarDocenteACursoResponse { Mensaje = $"Ya hay un docente que imparte esta asignatura en el curso {curso.Id}" };
                }
            }
            else
            {
                return new AsignarDocenteACursoResponse { Mensaje = $"Este docente ya se encuentra asignado a este curso" };
            }
        }
    }

    public class AsignarDocenteACursoRequest
    {
        public long CodigoCurso { get; set; }
        public long NumeroIdentificacionDocente { get; set; }
        public long CodigoAsignatura { get; set; }
    }
    public class AsignarDocenteACursoResponse
    {
        public string Mensaje { get; set; }
    }
}
