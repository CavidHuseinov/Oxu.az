
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Oxu.Infrastructure;
using Oxu.Persistance;
using Oxu.Presentation;

namespace Oxu.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(AssemblyReference.Assembly));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            PersistanceServiceRegistration.AddPersistance(builder.Services, builder.Configuration);
            PersistanceServiceRegistration.AddDIRepositories(builder.Services);
            InfrastructureServiceRegistration.AddInfrastructure(builder.Services);
            InfrastructureServiceRegistration.AddDIServices(builder.Services);

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
