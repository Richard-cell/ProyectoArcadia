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
    public class EstudianteController : ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public EstudianteController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet("ConsultarEstudiante/{id}")]
        public ActionResult<ConsultarEstudianteResponse> Get(long id)
        {
            ConsultarEstudianteService service = new ConsultarEstudianteService(_unitOfWork);
            ConsultarEstudianteResponse response = service.Ejecutar(new ConsultarEstudianteRequest { IdConsultar = id });
            return Ok(response);
        }

        [HttpPut("Modificar Estudiante")]
        public ActionResult<ModificarEstudianteResponse> Put(ModificarEstudianteRequest request)
        {
            ModificarEstudianteService service = new ModificarEstudianteService(_unitOfWork);
            ModificarEstudianteResponse response = service.Ejecutar(request);
            return Ok(response);
        }
    }
}
