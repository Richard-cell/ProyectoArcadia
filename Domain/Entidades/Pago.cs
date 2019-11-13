using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Pago: Entity<int>
    {
        public long CodigoPago { get; private set; }
        public DateTime FechaPago { get; private set; }
        public DateTime FechaLimitePago { get; private set; }
        public float ValorPago { get;private set; }
        public float InteresPago { get; private set; }
        public int PensionEscolarId { get; private set; }

        public Pago()
        {
        }

        public Pago(long codigoPago, DateTime fechaPago, DateTime fechaLimitePago, float valorPago, float interesPago)
        {
            CodigoPago = codigoPago;
            FechaPago = fechaPago;
            FechaLimitePago = fechaLimitePago;
            ValorPago = valorPago;
            InteresPago = interesPago;
        }
    }
}
