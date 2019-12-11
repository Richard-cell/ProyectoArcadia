using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Nota : Entity<long>
    {
        public float NotaPrimerPeriodo { get;  set; }
        public float NotaSegundoPeriodo { get;  set; }
        public float NotaTercerPeriodo { get;  set; }
        public float NotaCuartoPeriodo { get;  set; }
        public float PromedioNota { get; private set; }
        public Asignatura Asignatura { get; private set; }
        public long? BoletinId { get; private set; }
        public long EstudianteId { get; private set; }

        public Nota()
        {
        }

        public Nota(long codigoNota,Asignatura asignatura,float notaPrimerPeriodo, float notaSegundoPeriodo, float notaTercerPeriodo, float notaCuartoPeriodo)
        {
            Id = codigoNota;
            NotaPrimerPeriodo = notaPrimerPeriodo;
            NotaSegundoPeriodo = notaSegundoPeriodo;
            NotaTercerPeriodo = notaTercerPeriodo;
            NotaCuartoPeriodo = notaCuartoPeriodo;
            Asignatura = asignatura;
            CalcularPromedio();
        }

        public void CalcularPromedio()
        {
            PromedioNota = (NotaPrimerPeriodo + NotaSegundoPeriodo + NotaTercerPeriodo + NotaCuartoPeriodo) / 4;
        }

        public static bool IsNotaValida(float notaUno, float notaDos, float notaTres, float notaCuatro) {
            return (notaUno < 0 || notaUno > 5) ||
                   (notaDos < 0 || notaDos > 5) ||
                   (notaTres < 0 || notaTres > 5) ||
                   (notaCuatro < 0 || notaCuatro > 5);               
        }
    }
}
