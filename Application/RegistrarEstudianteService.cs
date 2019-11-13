using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarEstudianteResponse Ejecutar(RegistrarEstudianteRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new RegistrarEstudianteResponse { Mensaje = $"Se registro al estudiante {request.DocumentoIdentidad}" };
            }
            else
            {
                return new RegistrarEstudianteResponse { Mensaje = $"El estudiante no exite" };
            }
        }
    }

    public class RegistrarEstudianteRequest
    {
        public string DocumentoIdentidad { get; set; }
        public int GradoAspirante { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreEstudiante { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public int Telefono { get; set; }
        public string RH { get; set; }
        public char Sexo { get; set; }
    }

    public class RegistrarEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}
