using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class AcudienteRepository : GenericRepository<Acudiente>, IAcudienteRepository
    {
        public AcudienteRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
