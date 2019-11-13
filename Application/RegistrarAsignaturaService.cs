using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarAsignaturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarAsignaturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarAsignaturaResponse Ejecutar(RegistrarAsignaturaRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new RegistrarAsignaturaResponse { Mensaje = $"Se registro la asignatura {request.Nombre}" };
            }
            else
            {
                return new RegistrarAsignaturaResponse { Mensaje = $"La asignatura ya exite" };
            }
        }
    }

    public class RegistrarAsignaturaRequest
    {
        public int CodAsignatura { get; set; }
        public string Nombre { get; set; }
    }

    public class RegistrarAsignaturaResponse
    {
        public string Mensaje { get; set; }
    }
}
