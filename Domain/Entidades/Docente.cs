﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Docente: Persona<long>
    {
        public int Edad { get; private set; }
        public int AñosExperiencia { get; private set; }
        public List<DocenteCurso> ListaDocenteCurso{ get; set; }
        public List<DocenteAsignatura> ListaDocenteAsignaturas { get; set; }
        public Docente()
        {
        }

        public Docente(string tipoDocumento, long numeroIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, long telefono, char sexo, int edad, int añosExperiencia, int estratoSocial, string correoElectronico): base(tipoDocumento, primerNombre, segundoNombre, primerApellido, segundoApellido, direccion, telefono, sexo, estratoSocial,correoElectronico)
        {
            Id = numeroIdentificacion;
            Edad = edad;
            AñosExperiencia = añosExperiencia;
            ListaDocenteAsignaturas = new List<DocenteAsignatura>();
        }

        public static bool IsValidarAñosExperiencia(int añosExperiencia) {
            return añosExperiencia < 2;
        }

        public bool IsAlmacenarCursosAsignados(DocenteCurso curso)
        {
            try
            {
                ListaDocenteCurso.Add(curso);
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                return false;
            }
        }

        public bool IsAlmacenarAsignaturasImpartidas(DocenteAsignatura asignatura)
        {
            try
            {
                ListaDocenteAsignaturas.Add(asignatura);
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
