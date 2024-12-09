using Application;
using Domain.Contracts;
using Infraestructure.Contextos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaCotroller : ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public MatriculaCotroller(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("Realizar Matricula")]
        public ActionResult<RealizarMatriculaResponse> Post(RealizarMatriculaRequest request)
        {
            RealizarMatriculaService service = new RealizarMatriculaService(_unitOfWork);
            RealizarMatriculaResponse response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarMatricula/{id}")]
        public ActionResult<ConsultarMatriculaResponse> Get(long id)
        {
            ConsultarMatriculaService service = new ConsultarMatriculaService(_unitOfWork);
            ConsultarMatriculaResponse response = service.Ejecutar(new ConsultarMatriculaRequest { IdConsultar = id });
            return Ok(response);
        }

        [HttpDelete("Cancelar Matricula")]
        public ActionResult<CancelarMatriculaResponse> Post(CancelarMatriculaRequest request)
        {
            CancelarMatriculaService service = new CancelarMatriculaService(_unitOfWork);
            CancelarMatriculaResponse response = service.Ejecutar(request);
            return Ok(response);
        }
    }
}
