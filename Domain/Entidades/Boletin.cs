using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Boletin: Entity<long>
    {
        public List<Nota> ListaNotas { get; private set; }

        public Boletin()
        {
        }

        public Boletin(long codigoBoletin, List<Nota> notas)
        {
            Id = codigoBoletin;
            ListaNotas = notas;
        }
    }
}
