using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using TeacherService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CT.Dinamo.Api.Aplicacion.Servicios
{
    public class TeacherProxy : ITeacherProxy
    {
        private readonly TeacherService.ITeacher _TeacherClient;
        public TeacherProxy()
        {
            _TeacherClient = new TeacherClient();
        }

        public async Task<List<TeacherService.TeacherDTO>> Get()
        {
            GetTeacherRequest request = new GetTeacherRequest();

            var res = await _TeacherClient.GetTeacherAsync(request);
            return res.GetTeacherResult;
        }

        public async Task<TeacherService.TeacherDTO> GetId(long id)
        {
            GetTeacherIdRequest request = new GetTeacherIdRequest();
            request.id = id;

            var res = await _TeacherClient.GetTeacherIdAsync(request);
            return res.GetTeacherIdResult;
        }

        public async Task<string> Add(TeacherRequest Teacher)
        {
            NewTeacherRequest request = new NewTeacherRequest();
            request.student = new TeacherRequest();
            request.student.Nombre = Teacher.Nombre;
            request.student.Telefono = Teacher.Telefono;

            var res = await _TeacherClient.NewTeacherAsync(request);
            return res.NewTeacherResult.ToString();
        }
    }
}
