using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarDocenteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarDocenteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarDocenteResponse Ejecutar(ConsultarDocenteRequest request)
        {
            Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x => x.Id == request.DocConsultar);
            if (docente != null)
            {
                return new ConsultarDocenteResponse 
                { 
                    Mensaje = $"Tipo documento: {docente.TipoDocumento}" +
                    $"Id: {docente.Id}" +
                    $"Nombre: {docente.PrimerNombre} {docente.SegundoNombre}" + 
                    $"Apellido: {docente.PrimerApellido} {docente.SegundoApellido}" + 
                    $"Direccion: {docente.Direccion}" + 
                    $"Telefono: {docente.Telefono}" + 
                    $"Sexo: {docente.Sexo}" + 
                    $"Edad: {docente.Edad}" + 
                    $"Años de experiencia: {docente.AñosExperiencia}" + 
                    $"Estrato: {docente.EstratoSocial}" + 
                    $"Correo electronico: {docente.CorreoElectronico}" 
                };
            }
            else
            {
                return new ConsultarDocenteResponse { Mensaje = $"El número de documento no existe" };
            }
        }
    }

    public class ConsultarDocenteRequest
    {
        public long DocConsultar { get; set; }
    }

    public class ConsultarDocenteResponse
    {
        public string Mensaje { get; set; }
    }

}
