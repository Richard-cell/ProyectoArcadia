using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Curso: Entity<int>
    {
        public long CodigoCurso { get; private set; }
        public int GradoCurso { get; private set; }
        public List<Docente> ListaDocentes { get; private set; }
        public List<Estudiante> ListaEstudiantes { get; private set; }

        public Curso()
        {
        }

        public Curso(long codigoCurso, int gradoCurso, List<Docente> listaDocentes, List<Estudiante> listaEstudiantes)
        {
            CodigoCurso = codigoCurso;
            GradoCurso = gradoCurso;
            ListaDocentes = listaDocentes;
            ListaEstudiantes = listaEstudiantes;
        }
    }
}
