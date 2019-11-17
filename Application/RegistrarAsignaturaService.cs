using Domain.Contracts;
using Domain.Entidades;
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
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x => x.Id == request.CodigoAsignatura);
            if (asignatura == null)
            {
                asignatura = new Asignatura(
                    request.CodigoAsignatura,
                    request.NombreAsignatura
                    );
                _unitOfWork.AsignaturaRepository.Add(asignatura);
                _unitOfWork.Commit();
                return new RegistrarAsignaturaResponse { Mensaje = $"Se registro correctamente la asignatura {request.NombreAsignatura}" };
            }
            else
            {
                return new RegistrarAsignaturaResponse { Mensaje = $"La asignatura ya existe" };
            }
        }
    }

    public class RegistrarAsignaturaRequest
    {
        public int CodigoAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
    }

    public class RegistrarAsignaturaResponse
    {
        public string Mensaje { get; set; }
    }
}
