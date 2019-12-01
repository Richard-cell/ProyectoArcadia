using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarMatriculaResponse Ejecutar(ConsultarMatriculaRequest request)
        {
            Matricula matricula = _unitOfWork.MatriculaRepository.FindFirstOrDefault(x => x.Id == request.IdConsultar);
            if (matricula != null)
            {
                return new ConsultarMatriculaResponse
                {
                    Mensaje = $"Id: {request.IdConsultar}" +
                    $"Fecha de matricula: {matricula.FechaMatricula}" + 
                    $"Numero de doc adjuntos: {matricula.NumeroDocumentosAdjuntados}" +
                    $"Valor matricula: {matricula.ValorMatricula}" +
                    $"estado de matricula: {matricula.EstadoMatricula}"  
                };
            }
            else
            {
                return new ConsultarMatriculaResponse { Mensaje = $"El curso no existe" };
            }
        }
    }

    public class ConsultarMatriculaRequest
    {
        public int IdConsultar { get; set; }
    }

    public class ConsultarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }

}
