using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RegistrarNotasService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegistrarNotasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegistrarNotasResponse Ejecutar(RegistrarNotasRequest request)
        {

            if (request == null)
            {


                _unitOfWork.Commit();
                return new RegistrarNotasResponse { Mensaje = $"Se registro la nota para el estudiante {request.DocEstudiante}" };
            }
            else
            {
                return new RegistrarNotasResponse { Mensaje = $"El estudiante no exite" };
            }
        }
    }

    public class RegistrarNotasRequest
    {
        public int CodNota { get; set; }
        public int CodAsignatura { get; set; }
        public string DocEstudiante { get; set; }
        public float NotaUno { get; set; }
        public float NotaDos { get; set; }
        public float NotaTres { get; set; }
        public float NotaCuatro { get; set; }
    }

    public class RegistrarNotasResponse
    {
        public string Mensaje { get; set; }
    }
}
