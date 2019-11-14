using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Acudiente: Persona<int>
    {
        public string Parentezco { get; private set; }
        public int EstudianteId { get; private set; }
        public int MatriculaId { get; private set; }
        public Acudiente() { }
        public Acudiente(string parentezco, string tipoDocumento,long numeroIdentificacion,string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int estratoSocial, string correoElectronico) :base(tipoDocumento, numeroIdentificacion,primerNombre,segundoNombre,primerApellido,segundoApellido,direccion,telefono, sexo, estratoSocial, correoElectronico) {
            Parentezco = parentezco;
        }
    }
}
