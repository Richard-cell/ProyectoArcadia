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
            
        }

        private void ConfigurarLlavesPrimarias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteAsignatura>().HasKey(x => new { x.Docente.NumeroIdentificacion, x.Asignatura.CodigoAsignatura });
            modelBuilder.Entity<DocenteCurso>().HasKey(x => new { x.Docente.NumeroIdentificacion, x.Curso.CodigoCurso });

            modelBuilder.Entity<Acudiente>().HasKey(x => x.NumeroIdentificacion);
            modelBuilder.Entity<Acudiente>().Property(x => x.NumeroIdentificacion).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Asignatura>().HasKey(x => x.CodigoAsignatura);
            modelBuilder.Entity<Asignatura>().Property(x => x.CodigoAsignatura).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Curso>().HasKey(x => x.CodigoCurso);
            modelBuilder.Entity<Curso>().Property(x => x.CodigoCurso).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Docente>().HasKey(x => x.NumeroIdentificacion);
            modelBuilder.Entity<Docente>().Property(x => x.NumeroIdentificacion).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Estudiante>().HasKey(x => x.NumeroIdentificacion);
            modelBuilder.Entity<Estudiante>().Property(x => x.NumeroIdentificacion).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Matricula>().HasKey(x => x.CodigoMatricula);
            modelBuilder.Entity<Matricula>().Property(x => x.CodigoMatricula).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<Nota>().HasKey(x => x.CodigoNota);
            modelBuilder.Entity<Nota>().Property(x => x.CodigoNota).ValueGeneratedNever().IsRequired();

            modelBuilder.Entity<PensionEscolar>().HasKey(x => x.CodigoPensionEscolar);
            modelBuilder.Entity<PensionEscolar>().Property(x => x.CodigoPensionEscolar).ValueGeneratedNever().IsRequired();
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
        public DbSet<Cuota> Pago { get; set; }
        public DbSet<PensionEscolar> PensionEscolar { get; set; }
    }
}
