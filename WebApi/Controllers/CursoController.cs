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
    public class CursoController: ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public CursoController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost]
        public ActionResult<RegistrarCursoResponse> Post(RegistrarCursoRequest request)
        {
            RegistrarCursoService _service = new RegistrarCursoService(_unitOfWork);
            RegistrarCursoResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarCurso/{id}")]
        public ActionResult<ConsultarCursoResponse> Get(long id)
        {
            ConsultarCursoService service = new ConsultarCursoService(_unitOfWork);
            ConsultarCursoResponse response = service.Ejecutar(new ConsultarCursoRequest { IdConsultar = id });
            return Ok(response);
        }
    }
}
