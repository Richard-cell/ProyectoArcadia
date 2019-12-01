using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarNotasService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarNotasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarNotasResponse Ejecutar(RegistrarNotasRequest request)
        {
            Nota nota = _unitOfWork.NotaRepository.FindFirstOrDefault(x => x.Id == request.CodAsignatura + request.DocEstudiante);
            if (nota == null)
            {
                if (!nota.IsNotaValida())
                {
                    nota.Id = request.CodAsignatura + request.DocEstudiante;
                    nota = new Nota(request.NotaUno, request.NotaDos, request.NotaTres, request.NotaCuatro);
                    _unitOfWork.NotaRepository.Add(nota);
                    _unitOfWork.Commit();
                    return new RegistrarNotasResponse { Mensaje = $"Se registro la nota para el estudiante {request.DocEstudiante}" };
                }
                else
                {
                    return new RegistrarNotasResponse { Mensaje = $"Error en las notas" };
                }
            }
            else
            {
                return new RegistrarNotasResponse { Mensaje = $"El estudiante no existe" };
            }
        }
    }

    public class RegistrarNotasRequest
    {
        public long CodAsignatura { get; set; }
        public long DocEstudiante { get; set; }
        public float NotaUno { get; set; }
        public float NotaDos { get; set; }
        public float NotaTres { get; set; }
        public float NotaCuatro { get; set; }
    }

    public class RegistrarNotasResponse
    {
        public string Mensaje { get; set; }
    }
}
