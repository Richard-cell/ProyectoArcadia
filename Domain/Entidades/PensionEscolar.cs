using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class PensionEscolar: Entity<int>
    {
        public long CodigoPensionEscolar { get; private set; }
        public DateTime FechaInicioPension { get; private set; }
        public DateTime FechaFinPension { get; private set; }
        public DateTime FechaLimitePagoPension { get; private set; }
        public string EstadoPensionEscolar { get; private set; }
        public List<Pago> Pagos { get; private set; }
        public int EstudianteId { get; private set; }

        public PensionEscolar()
        {
        }

        public PensionEscolar(long codigoPensionEscolar, DateTime fechaInicioPension, DateTime fechaFinPension, DateTime fechaLimitePagoPension, string estadoPensionEscolar)
        {
            CodigoPensionEscolar = codigoPensionEscolar;
            FechaInicioPension = fechaInicioPension;
            FechaFinPension = fechaFinPension;
            FechaLimitePagoPension = fechaLimitePagoPension;
            EstadoPensionEscolar = estadoPensionEscolar;
        }

        public bool IsAlmacenarPago(Pago pago)
        {
            try
            {
                Pagos.Add(pago);
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
