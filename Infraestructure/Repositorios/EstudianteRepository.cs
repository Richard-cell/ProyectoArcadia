using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
