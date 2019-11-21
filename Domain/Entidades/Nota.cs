using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Nota : Entity<int>
    {
        public float NotaPrimerPeriodo { get; private set; }
        public float NotaSegundoPeriodo { get; private set; }
        public float NotaTercerPeriodo { get; private set; }
        public float NotaCuartoPeriodo { get; private set; }
        public float PromedioNota { get; private set; }
        public int AsignaturaId { get; private set; }
        public int? BoletinId { get; private set; }
        public int EstudianteId { get; private set; }

        public Nota()
        {
        }

        public Nota(float notaPrimerPeriodo, float notaSegundoPeriodo, float notaTercerPeriodo, float notaCuartoPeriodo)
        {
            Id = AsignaturaId + EstudianteId;
            NotaPrimerPeriodo = notaPrimerPeriodo;
            NotaSegundoPeriodo = notaSegundoPeriodo;
            NotaTercerPeriodo = notaTercerPeriodo;
            NotaCuartoPeriodo = notaCuartoPeriodo;
            CalcularPromedio();
        }

        private void CalcularPromedio()
        {
            PromedioNota = (NotaPrimerPeriodo + NotaSegundoPeriodo + NotaTercerPeriodo + NotaCuartoPeriodo) / 4;
        }

        public bool IsNotaValida() {
            return (NotaPrimerPeriodo < 0 || NotaPrimerPeriodo > 5) ||
                   (NotaSegundoPeriodo < 0 || NotaSegundoPeriodo > 5) ||
                   (NotaTercerPeriodo < 0 || NotaTercerPeriodo > 5) ||
                   (NotaCuartoPeriodo < 0 || NotaCuartoPeriodo > 5);               
        }
    }
}
