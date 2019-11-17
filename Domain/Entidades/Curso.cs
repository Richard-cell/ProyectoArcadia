using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entidades
{
    public class Curso : Entity<int>
    {
        public long CodigoCurso { get; private set; }
        public int GradoCurso { get; private set; }
        public List<DocenteCurso> ListaDocenteCurso { get; set; }
        public List<Estudiante> ListaEstudiantes { get; set; }

        public Curso()
        {
        }

        public Curso(long codigoCurso, int gradoCurso)
        {
            CodigoCurso = codigoCurso;
            GradoCurso = gradoCurso;
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

        public bool IsAlmacenarDocentes(List<DocenteCurso> docentes) {
            try
            {
                foreach (var docente in docentes)
                {
                    ListaDocenteCurso.Add(docente);
                }
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
    }
}
