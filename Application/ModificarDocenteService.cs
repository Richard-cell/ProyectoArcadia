using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarDocenteResponse Ejecutar(ModificarDocenteRequest request)
        {
            Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x => x.Id == request.DocumentoId);
            if (docente != null)
            {


                _unitOfWork.Commit();
                return new ModificarDocenteResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
            }
            else
            {
                return new ModificarDocenteResponse { Mensaje = $"El número de documento no existe" };
            }
        }
    }

    public class ModificarDocenteRequest
    {
        public long DocumentoId { get; set; }
    }

    public class ModificarDocenteResponse
    {
        public string Mensaje { get; set; }
    }
}
