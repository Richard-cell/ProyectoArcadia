using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarNotasService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarNotasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarNotasResponse Ejecutar(ModificarNotasRequest request)
        {
            Nota nota = _unitOfWork.NotaRepository.FindFirstOrDefault(x => x.Id == request.CodAsignatura + request.DocEstudiante);
            if (nota != null)
            {
                if (!nota.IsNotaValida())
                {
                    nota.Id = request.CodAsignatura + request.DocEstudiante;
                    nota = new Nota(request.NotaUno, request.NotaDos, request.NotaTres, request.NotaCuatro);
                    _unitOfWork.NotaRepository.Edit(nota);
                    _unitOfWork.Commit();
                    return new ModificarNotasResponse { Mensaje = $"Se modifico la nota al estudiante {request.DocEstudiante}" };
                }
                else
                {
                    return new ModificarNotasResponse { Mensaje = $"Error en las notas" };
                }
            }
            else
            {
                return new ModificarNotasResponse { Mensaje = $"El estudiante no existe" };
            }
        }
    }

    public class ModificarNotasRequest
    {
        public long CodAsignatura { get; set; }
        public long DocEstudiante { get; set; }
        public float NotaUno { get; set; }
        public float NotaDos { get; set; }
        public float NotaTres { get; set; }
        public float NotaCuatro { get; set; }
    }

    public class ModificarNotasResponse
    {
        public string Mensaje { get; set; }
    }
}
