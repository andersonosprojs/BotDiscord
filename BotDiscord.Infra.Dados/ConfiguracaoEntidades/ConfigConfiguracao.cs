using BotDiscord.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotDiscord.Infra.Dados.ConfiguracaoEntidades
{
    public class ConfigConfiguracao : IEntityTypeConfiguration<ConfigDominio>
    {
        public void Configure(EntityTypeBuilder<ConfigDominio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserDataDir)
                .IsRequired();

            builder.Property(p => p.ExecutablePath)
                .IsRequired();

            builder.Property(p => p.Channel)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.Headless);
            builder.Property(p => p.Height);
            builder.Property(p => p.Width);
            builder.Property(p => p.TimeoutClose);


            builder.HasData(
              new ConfigDominio(
                  1,
                  "C:\\Users\\andersono\\AppData\\Local\\Google\\Chrome\\User Data\\Default", 
                  "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
                  false,
                  1000,
                  800, 
                  "https://discord.com/channels/704737085126475776/763005091997286420", 
                  5000)
            );
        }
    }
}
