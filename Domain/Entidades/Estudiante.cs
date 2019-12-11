using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Estudiante: Persona<long>
    {
        private static List<string> _listaRH;
        public string LugarNacimiento { get;  set; }
        public DateTime FechaNacimiento { get;  set; }
        public string RH { get;  set; }
        public int NumeroHermanos { get;  set; }
        public int LugarEntreHermanos { get;  set; }
        public string SeguroSocial { get;  set; }
        public float PuntajeSisben { get;  set; }
        public long MatriculaId { get;  set; }
        public long? CursoId { get;  set; }
        public long AcudienteId { get;  set; }
        public PensionEscolar PensionEscolar { get;  set; }
        public List<Nota> ListaNotas { get; set; }

        public Estudiante()
        {
        }

        public Estudiante(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, string lugarNacimiento, DateTime fechaNacimiento, string rH, int numeroHermanos, int lugarEntreHermanos, string seguroSocial, int estratoSocial, float puntajeSisben, char sexo, string correoElectronico,PensionEscolar pensionEscolar) :base(tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,direccion,telefono, sexo, estratoSocial, correoElectronico)
        {
            Id = numeroIdentificacion;
            LugarNacimiento = lugarNacimiento;
            FechaNacimiento = fechaNacimiento;
            RH = rH;
            NumeroHermanos = numeroHermanos;
            LugarEntreHermanos = lugarEntreHermanos;
            SeguroSocial = seguroSocial;
            PuntajeSisben = puntajeSisben;
            PensionEscolar = pensionEscolar;
            ListaNotas = new List<Nota>();
            AlmacenarRHValidos();
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

        public static bool IsValidarRH(string RH)
        {
            bool RHvalido = false;
            foreach (var tipoSangre in _listaRH)
            {
                if (tipoSangre.Equals(RH))
                {
                    RHvalido = true;
                    break;
                }
            }
            return RHvalido;
        }

        public static bool IsValidarPuntajeSisben(float puntajeSisben)
        {
            if (puntajeSisben<0 || puntajeSisben>60)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AlmacenarRHValidos()
        {
            _listaRH = new List<string>();
            _listaRH.Add("O+");
            _listaRH.Add("O-");
            _listaRH.Add("A+");
            _listaRH.Add("A-");
            _listaRH.Add("B+");
            _listaRH.Add("B-");
            _listaRH.Add("AB+");
            _listaRH.Add("AB-");
        }
    }
}
