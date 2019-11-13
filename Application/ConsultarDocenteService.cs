using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarDocenteResponse Ejecutar(ConsultarDocenteRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new ConsultarDocenteResponse { Mensaje = $"el docente {} con documento {request.DocConsultar} imparte la asignatura {}" };
            }
            else
            {
                return new ConsultarDocenteResponse { Mensaje = $"El número de documento no exite" };
            }
        }
    }

    public class ConsultarDocenteRequest
    {
        public int DocConsultar { get; set; }
    }

    public class ConsultarDocenteResponse
    {
        public string Mensaje { get; set; }
    }

}
