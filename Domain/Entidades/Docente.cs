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
        public List<DocenteCurso> DocenteCurso{ get; set; }
        public List<DocenteAsignatura> DocenteAsignatura { get; set; }
        public Docente()
        {
        }

        public Docente(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int edad, int añosExperiencia): base(tipoDocumento, numeroIdentificacion, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion, telefono, sexo)
        {
            Edad = edad;
            AñosExperiencia = añosExperiencia;
        }

        public bool IsValidarAñosExperiencia() {
            return AñosExperiencia < 2;
        }

        public bool IsAlmacenarCursosAsignados(List<DocenteCurso> curso)
        {
            try
            {
                DocenteCurso = curso;
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public bool IsAlmacenarAsignaturasImpartidas(List<DocenteAsignatura> asignatura)
        {
            try
            {
                DocenteAsignatura = asignatura;
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
