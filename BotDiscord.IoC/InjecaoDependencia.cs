using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Mappings;
using BotDiscord.Aplicacao.Servicos;
using BotDiscord.Dominio.Interfaces;
using BotDiscord.Infra.Dados.Contexto;
using BotDiscord.Infra.Dados.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotDiscord.Infra.IoC;

public static class InjecaoDependencia
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"
        ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IBotRepositorio, BotRepositorio>();
        services.AddScoped<IBotServico, BotServico>();

        services.AddScoped<IDiaRepositorio, DiaRepositorio>();
        services.AddScoped<IDiaServico, DiaServico>();

        services.AddAutoMapper(typeof(DominioModelProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("BotDiscord.Aplicacao");
        services.AddMediatR(myhandlers);

        return services;
    }
}
