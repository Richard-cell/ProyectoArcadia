using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarDocenteResponse Ejecutar(RegistrarDocenteRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new RegistrarDocenteResponse { Mensaje = $"Se creó con registro correctamente al docente {request.DocumentoIdentidad}" };
            }
            else
            {
                return new RegistrarDocenteResponse { Mensaje = $"El número de documento ya exite" };
            }
        }
    }

    public class RegistrarDocenteRequest
    {
        public string DocumentoIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public char Sexo { get; set; }
        public int Telefono { get; set; }
        public int Estrato { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public int AñosExperiencia { get; set; }
        public string AsignaturaImpartir { get; set; }
    }

    public class RegistrarDocenteResponse
    {
        public string Mensaje { get; set; }
    }
}
