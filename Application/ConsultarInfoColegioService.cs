using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsultarInfoColegioService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarInfoColegioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ConsultarInfoColegioResponse Ejecutar(ConsultarInfoColegioRequest request)
        {
            ColegioInfoSingleton colegioInfo = ColegioInfoSingleton.Instance();
            switch (request.InfoDeseada)
            {
                case "Nombre del colegio":
                    return new ConsultarInfoColegioResponse { Mensaje = colegioInfo.NombreColegio() };
                case "Mision del colegio":
                    return new ConsultarInfoColegioResponse { Mensaje = colegioInfo.MisionColegio() };
                case "Vision del colegio":
                    return new ConsultarInfoColegioResponse { Mensaje = colegioInfo.VisionColegio() };
                case "Informacion de contacto del colegio":
                    return new ConsultarInfoColegioResponse { Mensaje = colegioInfo.InformacionGeneral() };
                case "Servicios prestados del colegio":
                    return new ConsultarInfoColegioResponse { Mensaje = colegioInfo.ServiciosPrestados() };
                default:
                    return new ConsultarInfoColegioResponse { Mensaje = "Digite una opcion valida" };
            }
        }
    }

    public class ConsultarInfoColegioRequest
    {
        public string InfoDeseada { get; set; }
    }

    public class ConsultarInfoColegioResponse
    {
        public string Mensaje { get; set; }
    }
}
