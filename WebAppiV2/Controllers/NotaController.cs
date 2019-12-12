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
    public class NotaController : ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public NotaController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("Crear Registro de Notas")]
        public ActionResult<CrearRegistroNotaEstudianteResponse> Post(CrearRegistroNotaEstudianteRequest request)
        {
            CrearRegistroNotaEstudianteService service = new CrearRegistroNotaEstudianteService(_unitOfWork);
            CrearRegistroNotaEstudianteResponse response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarNota/{id}")]
        public ActionResult<ConsultarNotaResponse> Get(long idAsignatura, long idEstudiante)
        {
            ConsultarNotaService service = new ConsultarNotaService(_unitOfWork);
            ConsultarNotaResponse response = service.Ejecutar(new ConsultarNotaRequest { IdAsignaturaConsultar = idAsignatura, DocEstudiante= idEstudiante });
            return Ok(response);
        }

        [HttpPut("Modificar Nota")]
        public ActionResult<ModificarNotasResponse> Put(ModificarNotasRequest request)
        {
            ModificarNotasService service = new ModificarNotasService(_unitOfWork);
            ModificarNotasResponse response = service.Ejecutar(request);
            return Ok(response);
        }
    }
}
