using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class PensionEscolar : Entity<long>
    {
        private readonly float _valorPension = 60000;
        public DateTime FechaInicioPension { get; set; }
        public float ValorPension { get; private set; }
        public List<Cuota> ListaCuotas { get; private set; }
        public long EstudianteId { get; private set; }

        public PensionEscolar()
        {
        }

        public PensionEscolar(long codigoPensionEscolar, DateTime fechaInicioPension)
        {
            Id = codigoPensionEscolar;
            FechaInicioPension = fechaInicioPension;
            ValorPension = _valorPension;
            IsAlmacenarCuotas();
        }

        public bool IsAlmacenarCuotas()
        {
            ListaCuotas = new List<Cuota>();
            try
            {
                for (int i = 0; i < 11; i++)
                {
                    Cuota cuota = new Cuota(
                        i,
                        FechaInicioPension.AddMonths(i),
                        "No Pagado",
                        ValorPension
                        );
                    ListaCuotas.Add(cuota);
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
