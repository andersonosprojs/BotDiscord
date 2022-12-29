using BotDiscord.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotDiscord.Infra.Dados.ConfiguracaoEntidades
{
    public class DiaConfiguracao : IEntityTypeConfiguration<DiaDominio>
    {
        public void Configure(EntityTypeBuilder<DiaDominio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            

            builder.HasData(
              new DiaDominio(1, "Domingo"),
              new DiaDominio(2, "Segunda-feira"),
              new DiaDominio(3, "Terça-feira"),
              new DiaDominio(4, "Quarta-feira"),
              new DiaDominio(5, "Quita-feira"),
              new DiaDominio(6, "Sexta-feira"),
              new DiaDominio(7, "Sábado")
            );
        }
    }
}
