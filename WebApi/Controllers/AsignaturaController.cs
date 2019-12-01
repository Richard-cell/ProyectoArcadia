using Application;
using Domain.Contracts;
using Infraestructure.Contextos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public AsignaturaController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost]
        public ActionResult<RegistrarAsignaturaResponse> Post(RegistrarAsignaturaRequest request)
        {
            RegistrarAsignaturaService _service = new RegistrarAsignaturaService(_unitOfWork);
            RegistrarAsignaturaResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarAsignatura/{id}")]
        public ActionResult<ConsultarAsignaturaResponse> Get(long id)
        {
            ConsultarAsignaturaService service = new ConsultarAsignaturaService(_unitOfWork);
            ConsultarAsignaturaResponse response = service.Ejecutar(new ConsultarAsignaturaRequest { IdConsultar = id });
            return Ok(response);
        }
    }
}
