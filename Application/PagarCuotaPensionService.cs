using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class PagarCuotaPensionService
    {
        readonly IUnitOfWork _unitOfWork;

        public PagarCuotaPensionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagarCuotaPensionResponse Ejecutar(PagarCuotaPensionRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(x=>x.Id==request.NumeroIdentificacionEstudiante);
            if (estudiante!=null)
            {
                int numeroCuotaAPagar = estudiante.PensionEscolar.BuscarNumeroCuotaAPagar();
                PensionEscolar pension = estudiante.PensionEscolar;
                if (pension.ValidarFechaPagoCorrecta(request.FechaPagoCuota))
                {
                    Cuota cuota = estudiante.PensionEscolar.ListaCuotas[numeroCuotaAPagar];
                    if (cuota.IsRealizarPagoCuota(request.FechaPagoCuota))
                    {
                        return new PagarCuotaPensionResponse { Mensaje = $"Se ha pagado la cuota del mes {numeroCuotaAPagar} correctamente, con un interes del {cuota.CalcularInteresCuota()}" };
                    }
                    else
                    {
                        return new PagarCuotaPensionResponse { Mensaje = $"No se ha podido realizar el pago de la cuota" };
                    }
                }
                else
                {
                    return new PagarCuotaPensionResponse { Mensaje = $"Fecha de pago incorrecta" };
                }
            }
            else
            {
                return new PagarCuotaPensionResponse { Mensaje = $"El estudiante no se encuentra registrado, verifique" };
            }
        }
    }

    public class PagarCuotaPensionRequest {
        public long NumeroIdentificacionEstudiante { get; set; }
        public DateTime FechaPagoCuota { get; set; }
    }
    public class PagarCuotaPensionResponse
    {
        public string Mensaje { get; set; }
    }
}
