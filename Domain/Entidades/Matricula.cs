using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Matricula: Entity<int>
    {
        private readonly float _valorMatriculaActual = 120000;
        public DateTime FechaMatricula { get; private set; }
        public Estudiante Estudiante { get; private set; }
        public Acudiente Acudiente { get; private set; }
        public int NumeroDocumentosAdjuntados { get;private set; }
        public float ValorMatricula { get; private set; }
        public string EstadoMatricula { get; private set; }

        public Matricula()
        {
        }

        public Matricula(int codigoMatricula, DateTime fechaMatricula, Estudiante estudiante, Acudiente acudiente, int numeroDocumentosAdjuntados, string estadoMatricula)
        {
            Id = codigoMatricula;
            FechaMatricula = fechaMatricula;
            Estudiante = estudiante;
            Acudiente = acudiente;
            NumeroDocumentosAdjuntados = numeroDocumentosAdjuntados;
            EstadoMatricula = estadoMatricula;
            ValorMatricula = _valorMatriculaActual;
        }

        public bool IsValidarNumeroDocumentos()
        {
            return NumeroDocumentosAdjuntados == 8;
        }
    }
}
