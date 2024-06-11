using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using StudentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CT.Dinamo.Api.Aplicacion.Servicios
{
    public class StudentProxy : IStudentProxy
    {
        private readonly StudentService.IStudent _studentClient;
        public StudentProxy()
        {
            _studentClient = new StudentClient();
        }

        public async Task<List<StudentService.StudentDTO>> Get(bool Filters)
        {
            GetStudentRequest request = new GetStudentRequest();
            request.conProgramas = Filters;

            var res = await _studentClient.GetStudentAsync(request);
            return res.GetStudentResult;
        }

        public async Task<StudentService.StudentDTO> GetId(long id, bool Filters)
        {
            GetStudentIdRequest request = new GetStudentIdRequest();
            request.id = id;
            request.conProgramas = Filters;

            var res = await _studentClient.GetStudentIdAsync(request);
            return res.GetStudentIdResult;
        }

        public async Task<string> EnrollProgram(StudentAssociationRequest studentAssociation)
        {
            EnrollProgramRequest request = new EnrollProgramRequest();
            request.studentAssociation = studentAssociation;

            var res = await _studentClient.EnrollProgramAsync(request);
            return res.EnrollProgramResult.ToString();
        }

        public async Task<List<StudentService.StudentDTO>> GetStudentxPrograms(long Id)
        {
            GetStudentxProgramsRequest request = new GetStudentxProgramsRequest();
            request.Id = Id;

            var res = await _studentClient.GetStudentxProgramsAsync(request);
            return res.GetStudentxProgramsResult;
        }

        public async Task<string> Add(StudentRequest student)
        {
            NewStudentRequest request = new NewStudentRequest();
            request.student = student;

            var res = await _studentClient.NewStudentAsync(request);
            return res.NewStudentResult.ToString();
        }

        public async Task<string> Update(StudentRequest student)
        {
            UpdateStudentRequest request = new UpdateStudentRequest();
            request.student = student;

            var res = await _studentClient.UpdateStudentAsync(request);
            return res.UpdateStudentResult.ToString();
        }

        public async Task<string> Delete(long Id)
        {
            DeleteStudentRequest request = new DeleteStudentRequest();
            request.id = Id;

            var res = await _studentClient.DeleteStudentAsync(request);
            return res.DeleteStudentResult.ToString();
        }
    }
}
