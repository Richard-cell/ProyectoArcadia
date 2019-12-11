using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ModificarNotasService
    {
        readonly IUnitOfWork _unitOfWork;

        public ModificarNotasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ModificarNotasResponse Ejecutar(ModificarNotasRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(x=>x.Id==request.NumeroIdentificacionEstudiante);
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x=>x.Id==request.CodigoAsignatura);

            Nota nota = null;
            if (estudiante!=null && asignatura!=null)
            {
                foreach (var notaEstudiante in estudiante.ListaNotas)
                {
                    if (notaEstudiante.Id==ConcatenarNumeros(estudiante.Id,asignatura.Id))
                    {
                        nota = notaEstudiante;
                        break;
                    }
                }
                if (!Nota.IsNotaValida(request.NotaUno,request.NotaDos,request.NotaTres,request.NotaCuatro))
                {
                    nota.NotaPrimerPeriodo = request.NotaUno;
                    nota.NotaSegundoPeriodo = request.NotaDos;
                    nota.NotaTercerPeriodo = request.NotaTres;
                    nota.NotaCuartoPeriodo = request.NotaCuatro;
                    nota.CalcularPromedio();
                    _unitOfWork.NotaRepository.Edit(nota);
                    _unitOfWork.Commit();
                    return new ModificarNotasResponse { Mensaje = $"Se ha modificado las notas de la asignatura {asignatura.NombreAsignatura} para el estudiante {estudiante.PrimerNombre}" };
                }
                else
                {
                    return new ModificarNotasResponse { Mensaje = $"El valor de laa notas debe estar entre 0 Y 5" };
                }
            }
            else
            {
                return new ModificarNotasResponse { Mensaje = $"Datos no encontrados verifique" };
            }
        }
        private long ConcatenarNumeros(long numero, long numero2)
        {
            string numeroFinal = numero.ToString() + numero2.ToString();
            return long.Parse(numeroFinal);
        }
    }

    public class ModificarNotasRequest
    {
        public long CodigoAsignatura { get; set; }
        public long NumeroIdentificacionEstudiante { get; set; }
        public float NotaUno { get; set; }
        public float NotaDos { get; set; }
        public float NotaTres { get; set; }
        public float NotaCuatro { get; set; }
    }

    public class ModificarNotasResponse
    {
        public string Mensaje { get; set; }
    }
}
