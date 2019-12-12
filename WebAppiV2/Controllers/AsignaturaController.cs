﻿using Application;
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
    public class AsignaturaController: ControllerBase
    {
        readonly ColegioContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public AsignaturaController(ColegioContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("Registrar Asignatura")]
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

        [HttpPost("Asignar Asignatura a docente")]
        public ActionResult<AsignarDocenteAsignaturaResponse> Post(AsignarDocenteAsignaturaRequest request)
        {
            AsignarDocenteAsignaturaService _service = new AsignarDocenteAsignaturaService(_unitOfWork);
            AsignarDocenteAsignaturaResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

        [HttpPut("Modificar Asignatura")]
        public ActionResult<ModificarAsignaturaResponse> Put(ModificarAsignaturaRequest request)
        {
            ModificarAsignaturaService _service = new ModificarAsignaturaService(_unitOfWork);
            ModificarAsignaturaResponse response = _service.Ejecutar(request);
            return Ok(response);
        }
    }
}
