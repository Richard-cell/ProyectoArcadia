using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class DocenteCurso
    {
        public long DocenteId { get; private set; }
        public int CursoId { get; private set; }
        public Docente Docente { get; private set; }
        public Curso Curso { get; private set; }

        public DocenteCurso() { }

        public DocenteCurso(Docente docente, Curso curso)
        {
            Docente = docente;
            Curso = curso;
        }
    }
}
