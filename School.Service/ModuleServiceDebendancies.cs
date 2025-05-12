using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IIns_SubjectService, Ins_SubjectService>();
            services.AddTransient<IDepartmentSubjectService, DepartmentSubjectService>();
            services.AddTransient<IStudentSubjectService, StudentSubjectService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddTransient<IFileService, FileService>();



            services.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            return services;

        }

    }
}
