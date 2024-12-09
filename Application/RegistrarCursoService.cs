using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarCursoResponse Ejecutar(RegistrarCursoRequest request)
        {
            Curso curso = _unitOfWork.CursoRepository.FindFirstOrDefault(x=>x.Id==request.CodigoCurso);
            if (curso == null)
            {
                if (Curso.IsValidarGradoCurso(request.Grado))
                {
                    curso = new Curso(request.CodigoCurso, request.Grado);
                    _unitOfWork.CursoRepository.Add(curso);
                    _unitOfWork.Commit();
                    return new RegistrarCursoResponse { Mensaje = $"Se registro correctamente el curso {curso.Id}" };
                }
                else
                {
                    return new RegistrarCursoResponse { Mensaje = $"El grado es incorrecto" };
                }
            }
            else
            {
                return new RegistrarCursoResponse { Mensaje = $"El curso ya existe" };
            }
        }
    }

    public class RegistrarCursoRequest
    {
        public long CodigoCurso { get; set; }
        public int Grado { get; set; }
    }

    public class RegistrarCursoResponse
    {
        public string Mensaje { get; set; }
    }
}
