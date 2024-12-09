using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarNotaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarNotaResponse Ejecutar(ConsultarNotaRequest request)
        {
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x => x.Id == request.IdAsignaturaConsultar);
            if (asignatura != null)
            {
                Nota nota = _unitOfWork.NotaRepository.FindFirstOrDefault(x => x.Id == ConcatenarNumeros(request.DocEstudiante,request.IdAsignaturaConsultar));
                if (nota != null)
                {
                    return new ConsultarNotaResponse
                    {
                        Mensaje = $"Id nota: {nota.Id}" +
                        $"asignatura: {asignatura.NombreAsignatura}" +
                        $"Nota 1° periodo: {nota.NotaPrimerPeriodo}" +
                        $"Nota 2° periodo: {nota.NotaSegundoPeriodo}" +
                        $"Nota 3° periodo: {nota.NotaTercerPeriodo}" +
                        $"Nota 4° periodo: {nota.NotaCuartoPeriodo}" +
                        $"Promedio de notas: {nota.PromedioNota}"
                    };
                }
                else
                {
                    return new ConsultarNotaResponse { Mensaje = $"No existen notas registradas" };
                }
                
            }
            else
            {
                return new ConsultarNotaResponse { Mensaje = $"La asignatura no existe" };
            }
        }

        private long ConcatenarNumeros(long numero, long numero2)
        {
            string numeroFinal = numero.ToString() + numero2.ToString();
            return long.Parse(numeroFinal);
        }
    }

    public class ConsultarNotaRequest
    {
        public long IdAsignaturaConsultar { get; set; }
        public long DocEstudiante { get; set; }
    }

    public class ConsultarNotaResponse
    {
        public string Mensaje { get; set; }
    }

}
