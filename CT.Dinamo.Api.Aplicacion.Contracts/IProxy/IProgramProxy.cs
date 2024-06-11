using ProgramService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CT.Dinamo.Api.Aplicacion.Contracts.IServicios
{
    public interface IProgramProxy
    {
        public Task<List<ProgramService.ProgramDTO>> Get();
        public Task<ProgramService.ProgramDTO> GetId(long id);
        public Task<List<ProgramService.ProgramDTO>> GetProgramsxStudent(long Id);
        public Task<string> Add(ProgramRequest Program);
    }
}
