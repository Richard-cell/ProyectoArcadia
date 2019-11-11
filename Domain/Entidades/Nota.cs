using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Nota: Entity<int>
    {
        public long CodigoNota { get; private set; }
        public float NotaPrimerPeriodo { get; private set; }
        public float NotaSegundoPeriodo { get; private set; }
        public float NotaTercerPeriodo { get; private set; }
        public float NotaCuartoPeriodo { get; private set; }
        public float PromedioNota { get; private set; }
        public Estudiante Estudiante { get; private set; }
        public Asignatura Asignatura { get; private set; }
        public int BoletinId { get; set; }

        public Nota()
        {
        }

        public Nota(long codigoNota, float notaPrimerPeriodo, float notaSegundoPeriodo, float notaTercerPeriodo, float notaCuartoPeriodo, Estudiante estudiante, Asignatura asignatura)
        {
            CodigoNota = codigoNota;
            NotaPrimerPeriodo = notaPrimerPeriodo;
            NotaSegundoPeriodo = notaSegundoPeriodo;
            NotaTercerPeriodo = notaTercerPeriodo;
            NotaCuartoPeriodo = notaCuartoPeriodo;
            Estudiante = estudiante;
            Asignatura = asignatura;
            CalcularPromedio();
        }

        public void CalcularPromedio()
        {
            PromedioNota = (NotaPrimerPeriodo+NotaSegundoPeriodo+NotaTercerPeriodo+NotaCuartoPeriodo) / 4;
        }
    }
}
