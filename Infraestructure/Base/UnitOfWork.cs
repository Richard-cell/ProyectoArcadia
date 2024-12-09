using Domain.Contracts;
using Domain.Repositorios;
using Infraestructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Base
{
    public sealed class UnitOfWork: IUnitOfWork
    {
        private IDbContext _dbContext;
        private IAcudienteRepository _acudienteRepository;
        private IAsignaturaRepository _asignaturaRepository;
        private IBoletinRepository _boletinRepository;
        private ICursoRepository _cursoRepository;
        private IDocenteRepository _docenteRepository;
        private IEstudianteRepository _estudianteRepository;
        private IMatriculaRepository _matriculaRepository;
        private INotaRepository _notaRepository;
        private IPensionEscolarRepository _pensionEscolarRepository;
        private IDocenteAsignaturaRepository _docenteAsignaturaRepository;

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        public IAcudienteRepository AcudienteRepository { get { return _acudienteRepository ?? (_acudienteRepository = new AcudienteRepository(_dbContext)); } }
        public IAsignaturaRepository AsignaturaRepository { get { return _asignaturaRepository ?? (_asignaturaRepository = new AsignaturaRepository(_dbContext)); } }
        public IBoletinRepository BoletinRepository { get { return _boletinRepository ?? (_boletinRepository = new BoletinRepository(_dbContext)); } }
        public ICursoRepository CursoRepository { get { return _cursoRepository ?? (_cursoRepository = new CursoRepository(_dbContext)); } }
        public IDocenteRepository DocenteRepository { get { return _docenteRepository ?? (_docenteRepository = new DocenteRepository(_dbContext)); } }
        public IEstudianteRepository EstudianteRepository { get { return _estudianteRepository ?? (_estudianteRepository = new EstudianteRepository(_dbContext)); } }
        public IMatriculaRepository MatriculaRepository { get { return _matriculaRepository ?? (_matriculaRepository = new MatriculaRepository(_dbContext)); } }
        public INotaRepository NotaRepository { get { return _notaRepository ?? (_notaRepository = new NotaRepository(_dbContext)); } }
        public IPensionEscolarRepository PensionEscolarRepository { get { return _pensionEscolarRepository ?? (_pensionEscolarRepository = new PensionEscolarRepository(_dbContext)); } }
        public IDocenteAsignaturaRepository DocenteAsignaturaRepository { get { return _docenteAsignaturaRepository ?? (_docenteAsignaturaRepository = new DocenteAsignaturaRepository(_dbContext)); } }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
