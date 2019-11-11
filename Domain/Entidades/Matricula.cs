using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Matricula: Entity<int>
    {
        public long CodigoMatricula { get; private set; }
        public DateTime FechaMatricula { get; private set; }
        public Estudiante Estudiante { get; private set; }
        public Acudiente Acudiente { get; private set; }
        public int NumeroDocumentosAdjuntados { get;private set; }
        public string EstadoMatricula { get; private set; }

        public Matricula()
        {
        }

        public Matricula(long codigoMatricula, DateTime fechaMatricula, Estudiante estudiante, Acudiente acudiente, int numeroDocumentosAdjuntados, string estadoMatricula)
        {
            CodigoMatricula = codigoMatricula;
            FechaMatricula = fechaMatricula;
            Estudiante = estudiante;
            Acudiente = acudiente;
            NumeroDocumentosAdjuntados = numeroDocumentosAdjuntados;
            EstadoMatricula = estadoMatricula;
        }
    }
}
