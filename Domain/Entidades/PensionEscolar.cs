using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class PensionEscolar : Entity<int>
    {

        public long CodigoPensionEscolar { get; private set; }
        public DateTime FechaInicioPension { get; set; }
        public float ValorPension { get; private set; }
        public List<Cuota> ListaCuotas { get; private set; }
        public int EstudianteId { get; private set; }

        public PensionEscolar()
        {
        }

        public PensionEscolar(long codigoPensionEscolar, DateTime fechaInicioPension)
        {
            CodigoPensionEscolar = codigoPensionEscolar;
            FechaInicioPension = fechaInicioPension;
            ValorPension = 60000;
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
                        100+EstudianteId,
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
