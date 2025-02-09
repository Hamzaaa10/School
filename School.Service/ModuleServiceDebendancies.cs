using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstract;
using School.Service.Implemintation;

namespace School.Service
{
    public static class ModuleServiceDebendancies
    {

        public static IServiceCollection AddServiceDebendancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            return services;

        }

    }
}
