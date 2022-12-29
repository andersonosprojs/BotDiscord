using BotDiscord.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BotDiscord.Infra.Dados.Contexto
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<DiaDominio> Dias { get; set; }
        public DbSet<BotDominio> Bots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
