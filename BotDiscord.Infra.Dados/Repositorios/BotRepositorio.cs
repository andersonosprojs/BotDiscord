using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;
using BotDiscord.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BotDiscord.Infra.Dados.Repositorios
{
    public class BotRepositorio : IBotRepositorio
    {
        private ApplicationDbContext _botContexto;

        public BotRepositorio(ApplicationDbContext contexto)
            => _botContexto = contexto;

        public async Task<BotDominio> ExcluirAsync(BotDominio bot)
        {
            _botContexto.Remove(bot);
            await _botContexto.SaveChangesAsync();
            return bot;
        }

        public async Task<IEnumerable<BotDominio>> ListarAsync()
        {
            return await _botContexto.Bots.ToListAsync();
        }

        public async Task<BotDominio> SalvarAsync(BotDominio bot)
        {
            if (bot.Id == 0)
                _botContexto.Add(bot);
            else
                _botContexto.Update(bot);

            await _botContexto.SaveChangesAsync();

            return bot;
        }

        public async Task<BotDominio> SelecionarAsync(long id)
        {
            return await _botContexto.Bots.FindAsync(id);
        }
    }
}
