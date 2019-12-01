using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarCursoResponse Ejecutar(ConsultarCursoRequest request)
        {
            Curso curso = _unitOfWork.CursoRepository.FindFirstOrDefault(x => x.Id == request.IdConsultar);
            if (curso != null)
            {
                return new ConsultarCursoResponse
                {
                    Mensaje = $"Id: {request.IdConsultar}" +
                    $"Grado: {curso.GradoCurso}"
                };
            }
            else
            {
                return new ConsultarCursoResponse { Mensaje = $"El curso no existe" };
            }
        }
    }

    public class ConsultarCursoRequest
    {
        public int IdConsultar { get; set; }
    }

    public class ConsultarCursoResponse
    {
        public string Mensaje { get; set; }
    }

}
