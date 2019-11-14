using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class Persona<T>: BaseEntity
    {
        public T Id { get; set; }
        public string TipoDocumento { get; set; }
        public long NumeroIdentificacion { get; private set; }
        public string PrimerNombre { get; private set; }
        public string SegundoNombre { get; private set; }
        public string PrimerApellido { get; private set; }
        public string SegundoApellido { get; private set; }
        public string Direccion { get; private set; }
        public long Telefono { get; private set; }
        public char Sexo { get; private set; }
        public int EstratoSocial { get; private set; }
        public string CorreoElectronico { get; private set; }

        public Persona() {}

        protected Persona(string tipoDocumento,long numeroIdentificacion,string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int estrato, string correoElectronico)
        {
            TipoDocumento = tipoDocumento;
            NumeroIdentificacion = numeroIdentificacion;   
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Direccion = direccion;
            Telefono = telefono;
            Sexo = sexo;
            EstratoSocial = estrato;
            CorreoElectronico = correoElectronico;
        }
    }
}
