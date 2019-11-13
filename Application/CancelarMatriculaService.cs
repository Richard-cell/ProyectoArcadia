using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CancelarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CancelarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CancelarMatriculaResponse Ejecutar(CancelarMatriculaRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new CancelarMatriculaResponse { Mensaje = $"Se cancelo la matricula {} con el codigo {request.CodMatricula}" };
            }
            else
            {
                return new CancelarMatriculaResponse { Mensaje = $"El codigo de matricula no exite" };
            }
        }
    }

    public class CancelarMatriculaRequest
    {
        public int CodMatricula { get; set; }
        public DateTime FechaMatricula { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public string MotivoCancelacion { get; set; }
    }

    public class CancelarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }
}
