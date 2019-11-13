using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarCursoService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarCursoResponse Ejecutar(RegistrarCursoRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new RegistrarCursoResponse { Mensaje = $"Se registro el curso {request.Salon}" };
            }
            else
            {
                return new RegistrarCursoResponse { Mensaje = $"El curso ya exite" };
            }
        }
    }

    public class RegistrarCursoRequest
    {
        public int CodCurso { get; set; }
        public int Salon { get; set; }
        public string Grado { get; set; }
        public string Jornada { get; set; }
    }

    public class RegistrarCursoResponse
    {
        public string Mensaje { get; set; }
    }
}
