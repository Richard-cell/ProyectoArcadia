using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarDocenteResponse Ejecutar(ModificarDocenteRequest request)
        {
            Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x => x.Id == request.DocumentoId);
            if (docente != null)
            {
                if (!Docente.IsValidarAñosExperiencia(request.AñosExperiencia))
                {
                    docente.PrimerNombre = request.PrimerNombre;
                    docente.SegundoNombre = request.SegundoNombre;
                    docente.PrimerApellido = request.PrimerApellido;
                    docente.SegundoApellido = request.SegundoApellido;
                    docente.Telefono = request.Telefono;
                    docente.EstratoSocial = request.Estrato;
                    docente.Direccion = request.Direccion;
                    docente.CorreoElectronico = request.Email;
                    docente.Edad = request.Edad;
                    docente.AñosExperiencia = request.AñosExperiencia;

                    _unitOfWork.DocenteRepository.Edit(docente);
                    _unitOfWork.Commit();
                    return new ModificarDocenteResponse { Mensaje = $"Se modifico la informacion del docente {request.DocumentoId}" };
                }
                else
                {
                    return new ModificarDocenteResponse { Mensaje = $"El docente debe tener minimo 2 años de XP" };
                }
            }
            else
            {
                return new ModificarDocenteResponse { Mensaje = $"El número de documento no existe" };
            }
        }
    }

    public class ModificarDocenteRequest
    {
        public long DocumentoId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public long Telefono { get; set; }
        public int Estrato { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public int AñosExperiencia { get; set; }
    }

    public class ModificarDocenteResponse
    {
        public string Mensaje { get; set; }
    }
}
