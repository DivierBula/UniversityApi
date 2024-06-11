using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using ProgramService;
using StudentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CT.Dinamo.Api.Aplicacion.Servicios
{
    public class ProgramProxy : IProgramProxy
    {
        private readonly ProgramService.IProgram _ProgramClient;
        public ProgramProxy()
        {
            _ProgramClient = new ProgramClient();
        }

        public async Task<List<ProgramService.ProgramDTO>> Get()
        {
            GetProgramRequest request = new GetProgramRequest();

            var res = await _ProgramClient.GetProgramAsync(request);
            return res.GetProgramResult;
        }

        public async Task<ProgramService.ProgramDTO> GetId(long id)
        {
            GetProgramIdRequest request = new GetProgramIdRequest();
            request.id = id;

            var res = await _ProgramClient.GetProgramIdAsync(request);
            return res.GetProgramIdResult;
        }

        public async Task<List<ProgramService.ProgramDTO>> GetProgramsxStudent(long Id)
        {
            GetProgramsXstudentRequest request = new GetProgramsXstudentRequest();
            request.Id = Id;

            var res = await _ProgramClient.GetProgramsXstudentAsync(request);
            return res.GetProgramsXstudentResult;
        }

        public async Task<string> Add(ProgramRequest Program)
        {
            NewProgramRequest request = new NewProgramRequest();
            request.Program = Program;

            var res = await _ProgramClient.NewProgramAsync(request);
            return res.NewProgramResult.ToString();
        }
    }
}
