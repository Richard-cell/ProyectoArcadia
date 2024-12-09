using Domain.Entidades;
using Domain.Repositorios;
using Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositorios
{
    public class DocenteAsignaturaRepository: GenericRepository<DocenteAsignatura>, IDocenteAsignaturaRepository
    {
        public DocenteAsignaturaRepository(IDbContext context)
             : base(context)
        {

        }
    }
}
