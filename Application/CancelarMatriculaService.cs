using Domain.Contracts;
using Domain.Entidades;
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
            Matricula matricula = _unitOfWork.MatriculaRepository.FindFirstOrDefault(t => t.Id == request.CodMatricula);
            if (matricula != null)
            {
                TimeSpan DiferenciaFechas = request.FechaCancelacion - matricula.FechaMatricula;
                if (DiferenciaFechas.Days<=15) {
                    _unitOfWork.MatriculaRepository.Delete(matricula);
                    _unitOfWork.Commit();
                    return new CancelarMatriculaResponse { Mensaje = $"Se cancelo la matricula con el codigo {request.CodMatricula}" };
                }
                else
                {
                    return new CancelarMatriculaResponse { Mensaje = $"El plazo para cancelar la matricula ya expiro" };
                }
            }
            else
            {
                return new CancelarMatriculaResponse { Mensaje = $"El codigo de matricula no exite" };
            }
        }
    }

    public class CancelarMatriculaRequest
    {
        public long CodMatricula { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public string MotivoCancelacion { get; set; }
    }

    public class CancelarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }
}
