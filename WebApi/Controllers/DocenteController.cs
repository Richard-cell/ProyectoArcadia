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
    public class DocenteController : ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public DocenteController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost]
        public ActionResult<RegistrarDocenteResponse> Post(RegistrarDocenteRequest request)
        {
            RegistrarDocenteService _service = new RegistrarDocenteService(_unitOfWork);
            RegistrarDocenteResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarDocente/{id}")]
        public ActionResult<ConsultarDocenteResponse> Get(long id)
        {
            ConsultarDocenteService service = new ConsultarDocenteService(_unitOfWork);
            ConsultarDocenteResponse response = service.Ejecutar(new ConsultarDocenteRequest { DocConsultar = id });
            return Ok(response);
        }
    }
}
