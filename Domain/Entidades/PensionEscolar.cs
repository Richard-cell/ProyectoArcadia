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
                for (int i = 0; i < 10; i++)
                {
                    Cuota cuota = new Cuota(
                        i,
                        FechaInicioPension.AddMonths(i), //Corrgir para que inicie un mes despues
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

        public int BuscarNumeroCuotaAPagar()
        {
            int numeroCuotaAPagar = 0;
            for (int i = 0; i < ListaCuotas.Count; i++)
            {
                if (ListaCuotas[i].EstadoCuota.Equals("No Pagado"))
                {
                    numeroCuotaAPagar = i;
                    break;
                }
            }
            return numeroCuotaAPagar;
        }

        public bool ValidarFechaPagoCorrecta(DateTime fechaPago)
        {
            return fechaPago >= FechaInicioPension;
        }
       
    }
}
