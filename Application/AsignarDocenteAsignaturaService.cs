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

        public AsignarDocenteAsignaturaResponse Ejecutar(AsignarDocenteAsignaturaRequest request)
        {
            Docente docente = BuscarDocente(request.NumeroIdentificacion);
            Asignatura asignatura = BuscarAsignatura(request.CodigoAsignatura);

            if (docente != null && asignatura != null)
            {
                if (ValidarRegistroExistente(request.NumeroIdentificacion, request.CodigoAsignatura) == null)
                {
                    DocenteAsignatura docenteAsignatura = new DocenteAsignatura(docente,asignatura );
                    docente.IsAlmacenarAsignaturasImpartidas(docenteAsignatura);
                    _unitOfWork.DocenteRepository.Edit(docente);
                    _unitOfWork.Commit();
                    return new AsignarDocenteAsignaturaResponse { Mensaje = $"Se le asigno al docente {docente.PrimerNombre} correctamente la asignatura de {asignatura.NombreAsignatura}" };
                }
                else
                {
                    return new AsignarDocenteAsignaturaResponse { Mensaje = $"El docente {docente.PrimerNombre} ya imparte la asignatura de {asignatura.NombreAsignatura}" };
                }
            }
            else {
                return new AsignarDocenteAsignaturaResponse { Mensaje = $"los datos no se encuentran registrados verifique" };
            }
            
        }

        public Docente BuscarDocente(long numeroIdentificacion)
        {
            return _unitOfWork.DocenteRepository.FindFirstOrDefault(x=> x.Id == numeroIdentificacion);
        }

        public Asignatura BuscarAsignatura(int codigoAsignatura)
        {
            return _unitOfWork.AsignaturaRepository.FindFirstOrDefault(x=>x.Id==codigoAsignatura);
        }

        public DocenteAsignatura ValidarRegistroExistente(long numeroIdentificacion, int codigoAsignatura)
        {
            return _unitOfWork.DocenteAsignaturaRepository.FindFirstOrDefault(x=>x.DocenteId == numeroIdentificacion && x.AsignaturaId==codigoAsignatura);
        }
        
    }
    public class AsignarDocenteAsignaturaRequest
    {
        public int CodigoAsignatura { get; set; }
        public long NumeroIdentificacion { get; set; }
    }

    public class AsignarDocenteAsignaturaResponse
    {
        public string Mensaje { get; set; }
    }
}
