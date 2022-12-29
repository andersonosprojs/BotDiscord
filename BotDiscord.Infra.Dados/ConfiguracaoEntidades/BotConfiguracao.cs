using BotDiscord.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotDiscord.Infra.Dados.ConfiguracaoEntidades
{
    public class BotConfiguracao : IEntityTypeConfiguration<BotDominio>
    {
        public void Configure(EntityTypeBuilder<BotDominio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Message)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.Hours)
                .IsRequired();

            builder.Property(p => p.Execute);

            builder.Property(p => p.Active);

            builder.Property(p => p.Days)
                .IsRequired();

            builder.HasData(
              new BotDominio(1, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Bom dia, Pessoal! ☀️ Bora bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 728, true, true),
              new BotDominio(2, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Daily vai começar em breve... https://meet.jit.si/ClassJokers" }, new() { 1, 2, 3, 4, 5 }, 758, true, true),
              new BotDominio(3, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Quem estiver em **chamados** dá uma olhada se o **Monitor Reinf** no servidor está 🆗" }, new() { 1, 2, 3, 4, 5 }, 800, true, true),
              new BotDominio(4, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1148, true, true),
              new BotDominio(5, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1158, true, true),
              new BotDominio(6, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1228, true, true),
              new BotDominio(7, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1248, true, true),
              new BotDominio(8, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1258, true, true),
              new BotDominio(9, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1258, true, true),
              new BotDominio(10, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1328, true, true),
              new BotDominio(11, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1358, true, true),
              new BotDominio(12, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" }, new() { 1, 2, 3, 4, 5 }, 1415, true, true),
              new BotDominio(13, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, por hoje é só! Não esqueçam de bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 1428, true, true),
              new BotDominio(14, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Final do dia chegando, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" }, new() { 1, 2, 3, 4, 5 }, 1648, true, true),
              new BotDominio(15, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Até amanhã, Pessoal! Não esqueçam de bater ponto ⏰",
                                         "🤖 **⚠️ ATENÇÃO ⚠️**  Bom final de semana, Pessoal! Não esqueçam de bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 1658, true, true)
            );

        }
    }
}
