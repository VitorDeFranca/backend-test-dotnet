using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteFCamara.Application.Interfaces;
using TesteFCamara.Application.Services;
using TesteFCamara.Domain.Interfaces;
using TesteFCamara.Persistence.Contexts;
using TesteFCamara.Persistence.Repositories;

namespace TesteFCamara.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlserver");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
        }
    }
}
