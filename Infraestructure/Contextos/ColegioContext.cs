using Domain.Base;
using Domain.Entidades;
using Infraestructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Contextos
{
    public class ColegioContext: DbContextBase
    {
        public ColegioContext(DbContextOptions options):base(options) { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            ConfigurarLlavesPrimarias(modelBuilder);
        }

        private void ConfigurarLlavesPrimarias(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Acudiente>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Asignatura>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Curso>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Docente>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Estudiante>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Matricula>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Nota>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<PensionEscolar>().Property(x => x.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<DocenteAsignatura>().HasKey(x => new { x.AsignaturaId, x.DocenteId });
            modelBuilder.Entity<DocenteCurso>().HasKey(x => new { x.CursoId, x.DocenteId });
        }

        public DbSet<Acudiente> Acudiente { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<Boletin> Boletin { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<DocenteAsignatura> DocenteAsignatura { get; set; }
        public DbSet<DocenteCurso> DocenteCurso { get; set; }
        public DbSet<Estudiante> Estudiante{ get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Cuota> Cuota { get; set; }
        public DbSet<PensionEscolar> PensionEscolar { get; set; }
    }
}
