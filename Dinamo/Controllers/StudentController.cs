using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentService;
using System;
using System.Threading.Tasks;

namespace Dinamo.Controllers
{
    [Route("api/Student")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStudentProxy _proxy;
        public StudentController(IStudentProxy proxy, ILogger<StudentController> logger)
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
                    Result = await _proxy.Get(true)
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
                    Result = await _proxy.GetId(id, true)
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

        [HttpPost]
        [Route("EnrollProgram")]
        public async Task<IActionResult> EnrollProgram([FromBody] StudentAssociationRequest studentAssociation) 
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.EnrollProgram(studentAssociation)
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
        [Route("GetStudentxProgram/{id}")]
        public async Task<IActionResult> GetStudentxProgram(long id)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.GetStudentxPrograms(id)
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

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] StudentRequest student)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Update(student)
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

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Delete(id)
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
        public async Task<IActionResult> Add([FromBody] StudentRequest student)
        {
            Response response;
            try
            {
                response = new Response()
                {
                    Codigo = TypeCodice.SUCESS,
                    Mensaje = "Consumo Exitoso",
                    Result = await _proxy.Add(student)
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
