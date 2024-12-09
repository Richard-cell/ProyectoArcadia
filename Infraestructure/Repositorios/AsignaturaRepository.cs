using Domain.Entidades;
using Infraestructure.Base;
using Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignaturaRepository
    {
        public AsignaturaRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
