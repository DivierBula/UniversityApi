using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgramService;
using System;
using System.Threading.Tasks;

namespace Dinamo.Controllers
{
    [Route("api/Program")]
    [ApiController]
    [Authorize]
    public class ProgramController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProgramProxy _proxy;
        public ProgramController(IProgramProxy proxy, ILogger<ProgramController> logger)
        {
            _proxy = proxy;
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Get()
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error Get: " + e.Message, e);
                response = new Response()
                {
                    Codigo = TypeCodice.ERROR,
                    Mensaje = e.Message.ToString(),
                    Result = null
                };
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.GetId(id)
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error Get: " + e.Message, e);
                response = new Response()
                {
                    Codigo = TypeCodice.ERROR,
                    Mensaje = e.Message.ToString(),
                    Result = null
                };
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProgramsxStudent/{id}")]
        public async Task<IActionResult> GetProgramsxStudent(long id)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.GetProgramsxStudent(id)
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error Get: " + e.Message, e);
                response = new Response()
                {
                    Codigo = TypeCodice.ERROR,
                    Mensaje = e.Message.ToString(),
                    Result = null
                };
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] ProgramRequest Program)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Add(Program)
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error Get: " + e.Message, e);
                response = new Response()
                {
                    Codigo = TypeCodice.ERROR,
                    Mensaje = e.Message.ToString(),
                    Result = null
                };
            }
            return Ok(response);
        }

    }
}
