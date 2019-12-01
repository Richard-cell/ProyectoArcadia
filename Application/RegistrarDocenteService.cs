using Domain.Contracts;
using Domain.Entidades;
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
            Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x=>x.Id==request.DocumentoIdentidad);
            if (docente == null)
            {
                if (!Docente.IsValidarAñosExperiencia(request.AñosExperiencia))
                {
                    docente = new Docente(
                    request.TipoDocumento,
                    request.DocumentoIdentidad,
                    request.PrimerNombre,
                    request.SegundoNombre,
                    request.PrimerApellido,
                    request.SegundoApellido,
                    request.Direccion,
                    request.Telefono,
                    request.Sexo,
                    request.Edad,
                    request.AñosExperiencia,
                    request.Estrato,
                    request.Email
                    );
                    _unitOfWork.DocenteRepository.Add(docente);
                    _unitOfWork.Commit();
                    return new RegistrarDocenteResponse { Mensaje = $"Se registro correctamente al docente {request.DocumentoIdentidad}" };
                }
                else {
                    return new RegistrarDocenteResponse { Mensaje = $"El docente debe tener minimo 2 años de XP" };
                }

                
            }
            else
            {
                return new RegistrarDocenteResponse { Mensaje = $"El número de documento ya exite" };
            }
        }
    }

    public class RegistrarDocenteRequest
    {
        public string TipoDocumento { get; set; }
        public long DocumentoIdentidad { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public char Sexo { get; set; }
        public long Telefono { get; set; }
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
