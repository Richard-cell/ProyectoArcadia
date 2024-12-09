using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
