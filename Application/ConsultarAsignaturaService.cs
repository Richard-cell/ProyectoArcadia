using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarAsignaturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarAsignaturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarAsignaturaResponse Ejecutar(ConsultarAsignaturaRequest request)
        {
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x => x.Id == request.IdConsultar);
            if (asignatura != null)
            {
                return new ConsultarAsignaturaResponse 
                { 
                    Mensaje = $"Id: {request.IdConsultar}" +
                    $"Nombre: {asignatura.NombreAsignatura}" 
                };
            }
            else
            {
                return new ConsultarAsignaturaResponse { Mensaje = $"La asignatura no existe" };
            }
        }
    }

    public class ConsultarAsignaturaRequest
    {
        public long IdConsultar { get; set; }
    }

    public class ConsultarAsignaturaResponse
    {
        public string Mensaje { get; set; }
    }

}
