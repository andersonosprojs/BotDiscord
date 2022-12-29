using BotDiscord.Dominio.Entidades;

namespace BotDiscord.Dominio.Interfaces
{
    public interface IConfigRepositorio
    {
        Task<ConfigDominio> SelecionarAsync();
        Task<ConfigDominio> AtualizarAsync(ConfigDominio configuracao);
        //Task<ConfigDominio> ExcluirAsync(ConfigDominio configuracao);
    }
}
