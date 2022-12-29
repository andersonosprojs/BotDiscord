using BotDiscord.Dominio.Entidades;

namespace BotDiscord.Dominio.Interfaces
{
    public interface IBotRepositorio
    {
        Task<IEnumerable<BotDominio>> ListarAsync();
        Task<BotDominio> SelecionarAsync(long id);
        Task<BotDominio> SalvarAsync(BotDominio bot);
        Task<BotDominio> ExcluirAsync(BotDominio bot);
    }
}
