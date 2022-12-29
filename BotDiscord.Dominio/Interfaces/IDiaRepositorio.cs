using BotDiscord.Dominio.Entidades;

namespace BotDiscord.Dominio.Interfaces
{
    public interface IDiaRepositorio
    {
        Task<IEnumerable<DiaDominio>> ListarAsync();
        Task<DiaDominio> SelecionarAsync(long id);
    }
}
