using Domain.Contracts;
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

            if (request == null)
            {


                _unitOfWork.Commit();
                return new ModificarNotasResponse { Mensaje = $"Se modifico la nota al estudiante {request.DocEstudiante}" };
            }
            else
            {
                return new ModificarNotasResponse { Mensaje = $"El estudiante no exite" };
            }
        }
    }

    public class ModificarNotasRequest
    {
        public int CodAsignatura { get; set; }
        public string DocEstudiante { get; set; }
    }

    public class ModificarNotasResponse
    {
        public string Mensaje { get; set; }
    }
}
