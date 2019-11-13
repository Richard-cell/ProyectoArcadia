using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Docente: Persona<int>
    {
        public int Edad { get; private set; }
        public int AñosExperiencia { get; private set; }
        public List<DocenteCurso> DocenteCurso{ get; private set; }
        public List<DocenteAsignatura> DocenteAsignatura { get; private set; }
        public Docente()
        {
        }

        public Docente(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int edad, int añosExperiencia): base(tipoDocumento, numeroIdentificacion, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion, telefono, sexo)
        {
            Edad = edad;
            AñosExperiencia = añosExperiencia;
        }
    }
}
