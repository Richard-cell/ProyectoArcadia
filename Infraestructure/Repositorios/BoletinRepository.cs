using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class BoletinRepository : GenericRepository<Boletin>, IBoletinRepository
    {
        public BoletinRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
