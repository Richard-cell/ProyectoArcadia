using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Boletin: Entity<int>
    {
        public long CodigoBoletin { get; private set; }
        public Nota Nota { get; private set; }

        public Boletin()
        {
        }

        public Boletin(long codigoBoletin, Nota nota)
        {
            CodigoBoletin = codigoBoletin;
            Nota = nota;
        }
    }
}
