using Domain.Contracts;
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

            if (request == null)
            {


                _unitOfWork.Commit();
                return new ModificarEstudianteResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
            }
            else
            {
                return new ModificarEstudianteResponse { Mensaje = $"El número de documento no exite" };
            }
        }
    }

    public class ModificarEstudianteRequest
    {
        public int DocumentoId { get; set; }
    }

    public class ModificarEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}