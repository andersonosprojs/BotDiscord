using BotDiscord.Aplicacao.Modelos;

namespace BotDiscord.Aplicacao.Interfaces
{
    public interface IConfigServico
    {
        Task<ConfigModel> SelecionarAsync();
        Task AtualizarAsync(ConfigModel config);
    }
}
