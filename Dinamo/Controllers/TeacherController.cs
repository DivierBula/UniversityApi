using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeacherService;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Dinamo.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITeacherProxy _proxy;
        public TeacherController(ITeacherProxy proxy, ILogger<TeacherController> logger)
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

        [HttpPut]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] TeacherRequest Teacher)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Add(Teacher)
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
