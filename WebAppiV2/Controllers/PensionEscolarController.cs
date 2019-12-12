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
    public class PensionEscolarController : ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public PensionEscolarController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("Pagar Cuota Pension ")]
        public ActionResult<PagarCuotaPensionResponse> Post(PagarCuotaPensionRequest request)
        {
            PagarCuotaPensionService service = new PagarCuotaPensionService(_unitOfWork);
            PagarCuotaPensionResponse response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarPension/{id,cuota}")]
        public ActionResult<ConsultarCuotaResponse> Get(long id, int nCuota)
        {
            ConsultarCuotaService service = new ConsultarCuotaService(_unitOfWork);
            ConsultarCuotaResponse response = service.Ejecutar(new ConsultarCuotaRequest { NumeroIdentificacionEstudiante = id, NumeroCuotaAConsultar=nCuota });
            return Ok(response);
        }
    }
}
