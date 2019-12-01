using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarCursoResponse Ejecutar(ModificarCursoRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new ModificarCursoResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
            }
            else
            {
                return new ModificarCursoResponse { Mensaje = $"El número de documento no existe" };
            }
        }
    }

    public class ModificarCursoRequest
    {
        public long DocumentoId { get; set; }
        public long nombre { get; set; }
    }

    public class ModificarCursoResponse
    {
        public string Mensaje { get; set; }
    }
}
