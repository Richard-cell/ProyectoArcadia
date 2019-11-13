using Domain.Contracts;
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

            if (request == null)
            {


                _unitOfWork.Commit();
                return new ModificarDocenteResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
            }
            else
            {
                return new ModificarDocenteResponse { Mensaje = $"El número de documento no exite" };
            }
        }
    }

    public class ModificarDocenteRequest
    {
        public int DocumentoId { get; set; }
    }

    public class ModificarDocenteResponse
    {
        public string Mensaje { get; set; }
    }
}
