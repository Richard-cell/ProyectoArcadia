using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RealizarMatriculaService
    {
        readonly IUnitOfWork _unitOfWork;

        public RealizarMatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RealizarMatriculaResponse Ejecutar(RealizarMatriculaRequest request)
        {
            Matricula matricula = _unitOfWork.MatriculaRepository.FindFirstOrDefault(t => t.CodigoMatricula == request.CodigoMatricula);
            if (matricula == null)
            {
                Matricula matriculaNueva = new Matricula();
                matriculaNueva.CodigoMatricula = request.CodigoMatricula;
                matriculaNueva.FechaMatricula = request.FechaMatricula;
                matriculaNueva.Estudiante = request.Estudiante;
                matriculaNueva.Acudiente = request.Acudiente;
                matriculaNueva.NumeroDocumentosAdjuntados = request.NumeroDocumentosAdjuntados;
                matriculaNueva.ValorMatricula = request.ValorMatricula;
                matriculaNueva.EstadoMatricula = request.EstadoMatricula;

                _unitOfWork.MatriculaRepository.Add(matriculaNueva);
                _unitOfWork.Commit();
                return new RealizarMatriculaResponse() { Mensaje = $"Se creó con exito la matricula {request.CodigoMatricula}" };
            }
            else
            {
                return new RealizarMatriculaResponse() { Mensaje = $"la matricula ya exite" };
            }
        }
    }

    public class RealizarMatriculaRequest
    {
        public long CodigoMatricula { get; private set; }
        public DateTime FechaMatricula { get; private set; }
        public Estudiante Estudiante { get; private set; }
        public Acudiente Acudiente { get; private set; }
        public int NumeroDocumentosAdjuntados { get; private set; }
        public float ValorMatricula { get; private set; }
        public string EstadoMatricula { get; private set; }
    }

    public class RealizarMatriculaResponse
    {
        public string Mensaje { get; set; }
    }
}
