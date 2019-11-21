using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Asignatura: Entity<int>
    {
        public string NombreAsignatura { get; private set; }
        public List<Nota> ListaNotas { get; private set; }
        public List<DocenteAsignatura> ListaDocenteAsignaturas { get; private set; }
        public Asignatura()
        {
        }

        public Asignatura(int codigoAsignatura, string nombreAsignatura)
        {
            Id = codigoAsignatura;
            NombreAsignatura = nombreAsignatura;
            ListaDocenteAsignaturas = new List<DocenteAsignatura>();
            ListaNotas = new List<Nota>();
        }

        public bool IsAlmacenarDocentes(DocenteAsignatura docente)
        {
            try
            {
                ListaDocenteAsignaturas.Add(docente);
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public bool IsAlmacenarNotas(Nota nota)
        {
            try
            {
                ListaNotas.Add(nota);
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }
    }
}
