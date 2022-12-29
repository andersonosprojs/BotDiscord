using BotDiscord.Aplicacao.Modelos;

namespace BotDiscord.Aplicacao.Interfaces
{
    public interface IBotServico
    {
        Task<IEnumerable<BotModel>> ListarAsync();
        Task<BotModel> SelecionarAsync(long id);
        Task SalvarAsync(BotModel bot);
        Task ExcluirAsync(long id);
    }
}
