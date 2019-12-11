using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CrearRegistroNotaEstudianteService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearRegistroNotaEstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearRegistroNotaEstudianteResponse Ejecutar(CrearRegistroNotaEstudianteRequest request)
        {
            Curso curso = _unitOfWork.CursoRepository.FindFirstOrDefault(x=>x.Id==request.CodigoCurso);
            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x=>x.Id==request.CodigoAsignatura);
            Nota nota;
            if (curso!=null && asignatura!=null)
            {
                if (curso.ListaEstudiantes.Count!=0)
                {
                    foreach (var estudiante in curso.ListaEstudiantes)
                    {
                        nota = _unitOfWork.NotaRepository.FindFirstOrDefault(x => x.EstudianteId == estudiante.Id);
                        if (nota==null)
                        {
                            nota = new Nota(ConcatenarNumeros(estudiante.Id,asignatura.Id),asignatura,0,0,0,0);
                            estudiante.ListaNotas.Add(nota);
                            _unitOfWork.EstudianteRepository.Edit(estudiante);
                            _unitOfWork.Commit();
                        }         
                    }
                    return new CrearRegistroNotaEstudianteResponse { Mensaje = $"Se han creado los registros de notas satisfactoriamente" };
                }
                else
                {
                    return new CrearRegistroNotaEstudianteResponse{ Mensaje = $"El curso no tiene registrado ningun estudiante" };
                }
            }
            else
            {
                return new CrearRegistroNotaEstudianteResponse { Mensaje = $"Datos no encontrados verifique" };
            }
        }

        private long ConcatenarNumeros(long numero, long numero2)
        {
            string numeroFinal = numero.ToString() + numero2.ToString();
            return long.Parse(numeroFinal);
        }

    }

    public class CrearRegistroNotaEstudianteRequest
    {
        public long CodigoCurso { get; set; }
        public long CodigoAsignatura { get; set; }
    }

    public class CrearRegistroNotaEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}
