using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class DocenteRepository : GenericRepository<Docente>, IDocenteRepository
    {
        public DocenteRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
