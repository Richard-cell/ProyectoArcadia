using Domain.Entidades;
using Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAcudienteRepository AcudienteRepository { get; }
        IAsignaturaRepository AsignaturaRepository { get; }
        IBoletinRepository BoletinRepository { get; }
        ICursoRepository CursoRepository { get; }
        IDocenteRepository DocenteRepository { get; }
        IEstudianteRepository EstudianteRepository { get; }
        IMatriculaRepository MatriculaRepository { get; }
        INotaRepository NotaRepository { get; }
        IPensionEscolarRepository PensionEscolarRepository { get; }
        int Commit();
    }
}
