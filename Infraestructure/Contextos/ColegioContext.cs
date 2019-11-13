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
            modelBuilder.Entity<DocenteAsignatura>().HasKey(x => new { x.Docente.NumeroIdentificacion, x.Asignatura.CodigoAsignatura });
            modelBuilder.Entity<DocenteCurso>().HasKey(x => new { x.Docente.NumeroIdentificacion, x.Curso.CodigoCurso });
            //comprbar si funciona modelBuilder.Entity<Persona<int>>().HasIndex(x => x.NumeroIdentificacion).IsUnique();
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
