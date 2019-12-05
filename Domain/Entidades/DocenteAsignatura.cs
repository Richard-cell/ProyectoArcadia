










































using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class DocenteAsignatura: BaseEntity
    {
        public long DocenteId { get; private set; }
        public int AsignaturaId { get; private set; }
        public Docente Docente { get; private set; }
        public Asignatura Asignatura { get; private set; }

        public DocenteAsignatura() { }

        public DocenteAsignatura(Docente docente, Asignatura asignatura)
        {
            Docente = docente;
            Asignatura = asignatura;
        }
    }
}
