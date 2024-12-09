using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Matricula: Entity<long>
    {
        private readonly float _valorMatriculaActual = 120000;
        public DateTime FechaMatricula { get; private set; }
        public Estudiante Estudiante { get; private set; }
        public int NumeroDocumentosAdjuntados { get;private set; }
        public float ValorMatricula { get; private set; }
        public string EstadoMatricula { get; private set; }

        public Matricula()
        {
        }

        public Matricula(long codigoMatricula, DateTime fechaMatricula, Estudiante estudiante, int numeroDocumentosAdjuntados, string estadoMatricula)
        {
            Id = codigoMatricula;
            FechaMatricula = fechaMatricula;
            Estudiante = estudiante;
            NumeroDocumentosAdjuntados = numeroDocumentosAdjuntados;
            EstadoMatricula = estadoMatricula;
            ValorMatricula = _valorMatriculaActual;
        }

        public static bool IsValidarNumeroDocumentos(int numeroDocumentos)
        {
            return numeroDocumentos == 8;
        }
    }
}
