using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Asignatura: Entity<int>
    {
        public long CodigoAsignatura { get; private set; }
        public string NombreAsignatura { get; private set; }
        public int NotaId { get; private set; }
        public List<DocenteAsignatura> DoceteAsignaturas { get; private set; }
        public Asignatura()
        {
        }

        public Asignatura(long codigoAsignatura, string nombreAsignatura)
        {
            CodigoAsignatura = codigoAsignatura;
            NombreAsignatura = nombreAsignatura;
        }
    }
}
