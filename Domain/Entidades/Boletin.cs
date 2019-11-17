using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Boletin: Entity<int>
    {
        public List<Nota> ListaNotas { get; private set; }

        public Boletin()
        {
        }

        public Boletin(int codigoBoletin, List<Nota> notas)
        {
            Id = codigoBoletin;
            ListaNotas = notas;
        }
    }
}
