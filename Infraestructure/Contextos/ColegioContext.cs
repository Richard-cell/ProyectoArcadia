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
        //Colocar dbset Correspondientes
    }
}
