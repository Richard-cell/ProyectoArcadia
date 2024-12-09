using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarAsignaturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarAsignaturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarAsignaturaResponse Ejecutar(ModificarAsignaturaRequest request)
        {
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x => x.Id == request.IdAsignatura);
            if (asignatura != null)
            {
                asignatura.NombreAsignatura = request.Nombre;
                _unitOfWork.AsignaturaRepository.Edit(asignatura);
                _unitOfWork.Commit();
                return new ModificarAsignaturaResponse { Mensaje = $"Se modifico el nombre de la asignatura" };
            }
            else
            {
                return new ModificarAsignaturaResponse { Mensaje = $"La asignatura no existe" };
            }
        }
    }

    public class ModificarAsignaturaRequest
    {
        public long IdAsignatura { get; set; }
        public string Nombre { get; set; }
    }

    public class ModificarAsignaturaResponse
    {
        public string Mensaje { get; set; }
    }
}
