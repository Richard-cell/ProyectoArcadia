using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entidades
{
    public class Curso : Entity<long>
    {
        public int GradoCurso { get; private set; }
        public List<DocenteCurso> ListaDocenteCurso { get; set; }
        public List<Estudiante> ListaEstudiantes { get; set; }

        public Curso()
        {
        }

        public Curso(long codigoCurso, int gradoCurso)
        {
            Id = codigoCurso;
            GradoCurso = gradoCurso;
            ListaDocenteCurso = new List<DocenteCurso>();
        }

        public bool IsValidarNumeroEstudiantes() {
            return ListaEstudiantes.Count > 40;
        }

        public bool IsAlmacenarEstudiantes(List<Estudiante> estudiantes) {
            try
            {
                foreach (var estudiante in estudiantes)
                {
                    ListaEstudiantes.Add(estudiante);
                }
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public bool IsAlmacenarDocentes(DocenteCurso docente) {
            try
            {
                ListaDocenteCurso.Add(docente);
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public static bool IsValidarGradoCurso(int grado)
        {
            if (grado<=0 || grado>=12 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidarDocenteExistenteEnCurso(long numeroIdentificacion)
        {
            bool encontrado = false;
            try
            {
                foreach (var docente in ListaDocenteCurso)
                {
                    if (docente.Docente.Id==numeroIdentificacion)
                    {
                        encontrado = true;
                        break;
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
            }
            return encontrado;
        }

        public bool IsValidarDocenteConMismaAsignatura(long codigoAsignatura)
        {
            bool encontrado = false;
            try
            {
                foreach (var docente in ListaDocenteCurso)
                {
                    foreach (var asignatura in docente.Docente.ListaDocenteAsignaturas)
                    {
                        if (asignatura.Asignatura.Id==codigoAsignatura)
                        {
                            encontrado = true;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
            }
            return encontrado;
        }
    }
}
