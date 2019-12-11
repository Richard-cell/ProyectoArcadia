using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class Persona<T>: BaseEntity
    {
        public T Id { get; set; }
        public string TipoDocumento { get;  set; }
        public string PrimerNombre { get;  set; }
        public string SegundoNombre { get;  set; }
        public string PrimerApellido { get;  set; }
        public string SegundoApellido { get;  set; }
        public string Direccion { get;  set; }
        public long Telefono { get;  set; }
        public char Sexo { get;  set; }
        public int EstratoSocial { get;  set; }
        public string CorreoElectronico { get;  set; }

        public Persona() {}

        protected Persona(string tipoDocumento,string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int estrato, string correoElectronico)
        {
            TipoDocumento = tipoDocumento;
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
