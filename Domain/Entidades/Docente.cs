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
        public List<DocenteCurso> ListaDocenteCurso{ get; set; }
        public List<DocenteAsignatura> ListaDocenteAsignaturas { get; set; }
        public Docente()
        {
        }

        public Docente(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int edad, int añosExperiencia, int estratoSocial, string correoElectronico): base(tipoDocumento, numeroIdentificacion, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion, telefono, sexo, estratoSocial,correoElectronico)
        {
            Edad = edad;
            AñosExperiencia = añosExperiencia;
        }

        public bool IsValidarAñosExperiencia() {
            return AñosExperiencia < 2;
        }

        public bool IsAlmacenarCursosAsignados(List<DocenteCurso> cursos)
        {
            try
            {
                foreach (var curso in cursos)
                {
                    ListaDocenteCurso.Add(curso);
                }
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public bool IsAlmacenarAsignaturasImpartidas(List<DocenteAsignatura> asignaturas)
        {
            try
            {
                foreach (var asignatura in asignaturas)
                {
                    ListaDocenteAsignaturas.Add(asignatura);
                }
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
