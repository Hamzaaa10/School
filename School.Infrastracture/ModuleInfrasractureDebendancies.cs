using Microsoft.Extensions.DependencyInjection;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.ImplemintationRepository;

namespace School.Infrastracture
{
    public static class ModuleInfrasractureDebendancies
    {
        public static IServiceCollection AddInfrasractureDebendancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IInstractorRepository, InstractorRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;

        }
    }
}
