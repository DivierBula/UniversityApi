using StudentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CT.Dinamo.Api.Aplicacion.Contracts.IServicios
{
    public interface IStudentProxy
    {
        public Task<List<StudentService.StudentDTO>> Get(bool Filters);
        public Task<StudentService.StudentDTO> GetId(long id, bool Filters);
        public Task<string> EnrollProgram(StudentAssociationRequest studentAssociation);
        public Task<List<StudentService.StudentDTO>> GetStudentxPrograms(long Id);
        public Task<string> Add(StudentRequest student);
        public Task<string> Update(StudentRequest student);
        public Task<string> Delete(long id);
    }
}
