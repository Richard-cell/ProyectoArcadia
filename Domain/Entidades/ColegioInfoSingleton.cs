using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public sealed class ColegioInfoSingleton
    {
        private readonly static ColegioInfoSingleton _instance = new ColegioInfoSingleton();

        private ColegioInfoSingleton() { }
        public static ColegioInfoSingleton Instance()
        {
            return _instance;
        }

        public string NombreColegio()
        {
            return "INSTITUCIÓN EDUCATIVA LA ARCADIA EN HUILA, ALGECIRAS";
        }

        public string MisionColegio()
        {
            return "Asumimos la responsabilidad de dar una formación integral a cada uno de nuestros alumnos en las distintas etapas de su desarrollo, " +
                "desde el respeto a sus creencias, poniendo el máximo empeño en el cultivo de valores humanos y en la creación de hábitos de estudio, " +
                "trabajo y convivencia para una excelente formación académica y personal, acorde a las demandas de nuestra sociedad actual.";
        }

        public string VisionColegio()
        {
            return "Ser la primera elección de las familias que garantice la formación académica, " +
                "la madurez emocional y la educación en valores necesarios para el futuro de sus hijos en un mundo tecnológico y global.";
        }

        public string InformacionGeneral()
        {
            return "Ciudad: Huila" +
                    "Direccion: Transversal 23 N 20 - 26  " +
                    "Telefono: 5845454" +
                    "E-Mail:iela@hotmail.es";
        }

        public string ServiciosPrestados()
        {
            return "Pre-escolar:Transición" +
                "Primaria en grado: 1,2,3,4,5" +
                "Secundaria en grado: 6,7,8,9,10,11";
        }
    }
}
