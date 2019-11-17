using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Asignatura: Entity<int>
    {
        public string NombreAsignatura { get; private set; }
        public int NotaId { get; private set; }
        public List<DocenteAsignatura> ListaDocenteAsignaturas { get; private set; }
        public Asignatura()
        {
        }

        public Asignatura(int codigoAsignatura, string nombreAsignatura)
        {
            Id = codigoAsignatura;
            NombreAsignatura = nombreAsignatura;
            ListaDocenteAsignaturas = new List<DocenteAsignatura>();
        }

        public bool IsAlmacenarDocentes(List<DocenteAsignatura> docentes)
        {
            try
            {
                foreach (var docente in docentes)
                {
                    ListaDocenteAsignaturas.Add(docente);
                } 
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
