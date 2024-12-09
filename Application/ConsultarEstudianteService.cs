using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarEstudianteResponse Ejecutar(ConsultarEstudianteRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(x => x.Id == request.IdConsultar);
            if (estudiante != null)
            {
                return new ConsultarEstudianteResponse
                {
                    Mensaje = $"Tipo documento: {estudiante.TipoDocumento}" +
                    $"Id: {estudiante.Id}" +
                    $"Nombre: {estudiante.PrimerNombre} {estudiante.SegundoNombre}" +
                    $"Apellido: {estudiante.PrimerApellido} {estudiante.SegundoApellido}" +
                    $"Direccion: {estudiante.Direccion}" +
                    $"Telefono: {estudiante.Telefono}" +
                    $"Lugar de nacimiento: {estudiante.LugarNacimiento}" +
                    $"Fecha de nacimiento: {estudiante.FechaNacimiento}" +
                    $"RH: {estudiante.RH}" +
                    $"Numero de hermanos: {estudiante.NumeroHermanos}" +
                    $"Lugar entre hermanos: {estudiante.LugarEntreHermanos}" +
                    $"seguro social: {estudiante.SeguroSocial}" +
                    $"Estrato: {estudiante.EstratoSocial}" +
                    $"Puntaje sisben: {estudiante.PuntajeSisben}" +
                    // $"Representate legal: {estudiante.RepresentanteLegal}" +
                    $"Sexo: {estudiante.Sexo}" +
                    $"Correo electronico: {estudiante.CorreoElectronico}"
                }; 
            }
            else
            {
                return new ConsultarEstudianteResponse { Mensaje = $"El estudiante no existe" };
            }
        }
    }

    public class ConsultarEstudianteRequest
    {
        public long IdConsultar { get; set; }
    }

    public class ConsultarEstudianteResponse
    {
        public string Mensaje { get; set; }
    }

}
