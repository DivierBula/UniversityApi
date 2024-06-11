using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherService;

namespace CT.Dinamo.Api.Aplicacion.Contracts.IServicios
{
    public interface ITeacherProxy
    {
        public Task<List<TeacherService.TeacherDTO>> Get();
        public Task<TeacherService.TeacherDTO> GetId(long id);
        public Task<string> Add(TeacherRequest Teacher);
    }
}
