using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Estudiante: Persona<int>
    {
        public string LugarNacimiento { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string RH { get; private set; }
        public int NumeroHermanos { get; private set; }
        public int LugarEntreHermanos { get; private set; }
        public string SeguroSocial { get; private set; }
        public float PuntajeSisben { get; private set; }
        public int MatriculaId { get; private set; }
        public int CursoId { get; private set; }
        public Acudiente RepresentanteLegal { get; private set; }
        public PensionEscolar PensionEscolar { get; private set; }
        public List<Nota> ListaNotas { get; set; }

        public Estudiante()
        {
        }

        public Estudiante(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, string lugarNacimiento, DateTime fechaNacimiento, string rH, int numeroHermanos, int lugarEntreHermanos, string seguroSocial, int estratoSocial, float puntajeSisben, Acudiente representanteLegal, char sexo, string correoElectronico,PensionEscolar pensionEscolar) :base(tipoDocumento,numeroIdentificacion,primerNombre,segundoNombre,primerApellido,segundoApellido,direccion,telefono, sexo, estratoSocial, correoElectronico)
        {
            LugarNacimiento = lugarNacimiento;
            FechaNacimiento = fechaNacimiento;
            RH = rH;
            NumeroHermanos = numeroHermanos;
            LugarEntreHermanos = lugarEntreHermanos;
            SeguroSocial = seguroSocial;
            PuntajeSisben = puntajeSisben;
            RepresentanteLegal = representanteLegal;
            PensionEscolar = pensionEscolar;
            ListaNotas = new List<Nota>();
        }

        public bool IsAlmacenarNota(List<Nota> notas)
        {
            try
            {
                foreach (var nota in notas)
                {
                    ListaNotas.Add(nota);
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
