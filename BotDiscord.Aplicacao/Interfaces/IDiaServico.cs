using BotDiscord.Aplicacao.Modelos;

namespace BotDiscord.Aplicacao.Interfaces
{
    public interface IDiaServico
    {
        Task<IEnumerable<DiaModel>> ListarAsync();
        Task<DiaModel> SelecionarAsync(long id);
    }
}
