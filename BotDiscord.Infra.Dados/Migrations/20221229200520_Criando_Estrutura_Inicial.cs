using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BotDiscord.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEstruturaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<List<string>>(type: "text[]", maxLength: 2000, nullable: false),
                    Hours = table.Column<int>(type: "integer", nullable: false),
                    Execute = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Days = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bots",
                columns: new[] { "Id", "Active", "Days", "Execute", "Hours", "Message" },
                values: new object[,]
                {
                    { 1L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 728, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  Bom dia, Pessoal! ☀️ Bora bater ponto ⏰" } },
                    { 2L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 758, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  Daily vai começar em breve... https://meet.jit.si/ClassJokers" } },
                    { 3L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 800, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  Quem estiver em **chamados** dá uma olhada se o **Monitor Reinf** no servidor está 🆗" } },
                    { 4L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1148, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Saída para o almoço" } },
                    { 5L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1158, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Saída para o almoço" } },
                    { 6L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1228, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Saída para o almoço" } },
                    { 7L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1248, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Volta do almoço" } },
                    { 8L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1258, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Volta do almoço" } },
                    { 9L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1258, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Saída para o almoço" } },
                    { 10L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1328, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Volta do almoço" } },
                    { 11L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1358, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Volta do almoço" } },
                    { 12L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1415, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" } },
                    { 13L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1428, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, por hoje é só! Não esqueçam de bater ponto ⏰" } },
                    { 14L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1648, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  Final do dia chegando, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" } },
                    { 15L, true, new List<int> { 1, 2, 3, 4, 5 }, true, 1658, new List<string> { "🤖 **⚠️ ATENÇÃO ⚠️**  Até amanhã, Pessoal! Não esqueçam de bater ponto ⏰", "🤖 **⚠️ ATENÇÃO ⚠️**  Bom final de semana, Pessoal! Não esqueçam de bater ponto ⏰" } }
                });

            migrationBuilder.InsertData(
                table: "Dias",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1L, "Domingo" },
                    { 2L, "Segunda-feira" },
                    { 3L, "Terça-feira" },
                    { 4L, "Quarta-feira" },
                    { 5L, "Quita-feira" },
                    { 6L, "Sexta-feira" },
                    { 7L, "Sábado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bots");

            migrationBuilder.DropTable(
                name: "Dias");
        }
    }
}
