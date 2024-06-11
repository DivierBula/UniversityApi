using AutoMapper;
using CT.Dinamo.Api.Aplicacion.Contracts.IServicios;
using CT.Dinamo.Api.Aplicacion.Contracts.Modelos;
using CT.Dinamo.Api.Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;
using StudentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades.ServiceCollection
{
    public static class ServiceCollectionRegister
    {

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            RegistrarProxy(services);
            return services;
        }

        private static IServiceCollection RegistrarProxy(IServiceCollection services)
        {
            services.AddTransient<IStudentProxy, StudentProxy>();
            services.AddTransient<IProgramProxy, ProgramProxy>();
            services.AddTransient<ITeacherProxy, TeacherProxy>();
            return services;
        }
    }
}
