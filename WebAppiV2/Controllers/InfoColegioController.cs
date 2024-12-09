using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Contracts;
using Infraestructure.Contextos;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoColegioController : Controller
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public InfoColegioController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet("Consultar informacion del colegio/{informacion}")]
        public ActionResult<ConsultarInfoColegioResponse> Get(string informacion)
        {
            ConsultarInfoColegioService service = new ConsultarInfoColegioService(_unitOfWork);
            ConsultarInfoColegioResponse response = service.Ejecutar(new ConsultarInfoColegioRequest { InfoDeseada=informacion });
            return Ok(response);
        }
    }
}