using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class NotaRepository : GenericRepository<Nota>, INotaRepository
    {
        public NotaRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
