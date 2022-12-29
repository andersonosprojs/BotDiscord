using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;
using BotDiscord.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BotDiscord.Infra.Dados.Repositorios
{
    public class ConfigRepositorio: IConfigRepositorio
    {
        private ApplicationDbContext _configContexto;

        public ConfigRepositorio(ApplicationDbContext contexto)
            => _configContexto = contexto;

        public async Task<ConfigDominio> AtualizarAsync(ConfigDominio configuracao)
        {
            _configContexto.Update(configuracao);
            await _configContexto.SaveChangesAsync();
            return configuracao;
        }

        public async Task<ConfigDominio> SelecionarAsync()
        {
            return await _configContexto.Configuracao.FirstOrDefaultAsync();
        }
    }
}
