using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarCuotaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarCuotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarCuotaResponse Ejecutar(ConsultarCuotaRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(x=>x.Id==request.NumeroIdentificacionEstudiante);
            if (estudiante!=null)
            {
                Cuota cuota = estudiante.PensionEscolar.ListaCuotas[request.NumeroCuotaAConsultar];
                return new ConsultarCuotaResponse 
                { 
                    Mensaje = $"Cuota Mes: {cuota.MesCuota}" +
                    $"Fecha Pago Cuota: {cuota.FechaPagoCuota}" +
                    $"Fecha Limite Pago Cuota: {cuota.FechaLimitePagoCuota}" +
                    $"Valor Cuota:{cuota.ValorCuota}" +
                    $"Valor Total a pagar: {cuota.ValorTotalAPagar}" +
                    $"Estado Cuota: {cuota.EstadoCuota}" 
                };
            }
            else
            {
                return new ConsultarCuotaResponse { Mensaje = $"El estudiante no se encuentra registrado, verifique" };
            }
        }
    }

    public class ConsultarCuotaRequest
    {
        public long NumeroIdentificacionEstudiante { get; set; }
        public int NumeroCuotaAConsultar { get; set; }
    }

    public class ConsultarCuotaResponse
    {
        public string Mensaje { get; set; }
    }
}
