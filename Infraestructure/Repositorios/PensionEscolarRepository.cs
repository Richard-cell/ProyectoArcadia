using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class PensionEscolarRepository : GenericRepository<PensionEscolar>, IPensionEscolarRepository
    {
        public PensionEscolarRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
