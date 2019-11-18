using Domain.Contracts;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AsignarDocenteAsignaturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public AsignarDocenteAsignaturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public AsignarDocenteAsignaturaResponse Ejecutar(AsignarDocenteAsignaturaRequest request)
        //{
        //    List<DocenteAsignatura> ListaDocenteAsignaturas;
        //    Docente docente = _unitOfWork.DocenteRepository.FindFirstOrDefault(x => x.Id==request.NumeroIdentificacion);
        //    if (docente!=null)
        //    {
        //        ListaDocenteAsignaturas = new List<DocenteAsignatura>();
        //        foreach (var asignaturas in request.ListaCodigosAsignaturas)
        //        {
        //            Asignatura asignatura = _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x=>x.Id==asignaturas);
        //            DocenteAsignatura docenteAsignatura = new DocenteAsignatura(docente,asignatura);
        //            ListaDocenteAsignaturas.Add(docenteAsignatura);
        //        }
        //        docente.IsAlmacenarAsignaturasImpartidas(ListaDocenteAsignaturas);
        //    }
        //    else
        //    {

        //    }
        //}

        public class AsignarDocenteAsignaturaRequest
        {
            public List<int> ListaCodigosAsignaturas { get; set; }
            public long NumeroIdentificacion { get; set; }
        }

        public class AsignarDocenteAsignaturaResponse
        {
            public string Mensaje { get; set; }
        }
    }
}
