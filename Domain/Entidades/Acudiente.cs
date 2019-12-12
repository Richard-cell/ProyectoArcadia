using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Acudiente: Persona<long>
    {
        private  static List<string> _listaParentezco;
        public string Parentezco { get; private set; }
        public Estudiante Estudiante { get; set; }
        public Acudiente() { }
        public Acudiente( string parentezco, string tipoDocumento,long numeroIdentificacion,string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int estratoSocial, string correoElectronico) :base(tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,direccion,telefono, sexo, estratoSocial, correoElectronico) {
            Id = numeroIdentificacion;
            Parentezco = parentezco;
            AlmacenarListaDeParientesPermitidos();
        }

        public static bool IsValidarParentezco(string parentezcoAcudiente)
        {
            bool parentezcoValido = false;
            foreach (var Parentezco in _listaParentezco)
            {
                if (Parentezco.Equals(parentezcoAcudiente))
                {
                    parentezcoValido = true;
                    break;
                }
            }
            return parentezcoValido;
        }

        public void AlmacenarListaDeParientesPermitidos()
        {
            _listaParentezco = new List<string>();
            _listaParentezco.Add("Abuelo");
            _listaParentezco.Add("Abuela");
            _listaParentezco.Add("Padre");
            _listaParentezco.Add("Madre");
            _listaParentezco.Add("Tio");
            _listaParentezco.Add("Tia");
        }

        protected override string getEstandarCorreo() { 
            return "@hotmail.com";
        }

    }
}
