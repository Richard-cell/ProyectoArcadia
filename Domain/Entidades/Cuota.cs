using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Cuota: Entity<int>
    {
        public long CodigoCuota { get; private set; }
        public int MesCuota { get; private set; }
        public DateTime FechaPagoCuota { get; private set; }
        public DateTime FechaLimitePagoCuota { get; private set; }
        public float ValorCuota { get;private set; }
        public float ValorTotalAPagar { get; private set; }
        public string EstadoCuota { get; private set; }
        public int PensionEscolarId { get; private set; }

        public Cuota()
        {
        }

        public Cuota(long codigoPago, int mesPago, DateTime fechaLimitePago, string estadoCuota, float valorCuota)
        {
            CodigoCuota = codigoPago;
            MesCuota = mesPago;
            FechaLimitePagoCuota = fechaLimitePago;
            EstadoCuota = estadoCuota;
            ValorCuota = valorCuota;
        }

        public float CalcularInteresCuota()
        {
            if (FechaPagoCuota > FechaLimitePagoCuota)
            {
                TimeSpan DiferenciaFechas = FechaPagoCuota - FechaLimitePagoCuota;
                float interesTotal = 0.1f;
                for (int i = 0; i < DiferenciaFechas.Days; i++)
                {
                    interesTotal += 0.05f;
                }
                return interesTotal;
            }
            else {
                return 0;
            }
            
        }

        public bool IsRealizarPagoCuota(DateTime fechaPago)
        {
            try
            {
                FechaPagoCuota = fechaPago;
                ValorTotalAPagar = ValorCuota + (ValorCuota * CalcularInteresCuota());
                EstadoCuota = "Pagado";
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
