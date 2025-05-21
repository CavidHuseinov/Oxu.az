
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Oxu.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
