using Microsoft.Extensions.DependencyInjection;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.ImplemintationRepository;
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
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            return services;

        }

    }
}
