using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstract;
using School.Service.Implemintation;
using System.Runtime.CompilerServices;

namespace School.Service
{
    public static class ModuleServiceDebendancies
    {
   
        public static IServiceCollection AddServiceDebendancies( this IServiceCollection services )
        {
            services.AddTransient<IStudentService, StudentService> ();  
            return services;

        }

    }
}
