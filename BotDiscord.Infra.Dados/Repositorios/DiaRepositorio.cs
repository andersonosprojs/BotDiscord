using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;
using BotDiscord.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BotDiscord.Infra.Dados.Repositorios
{
    public class DiaRepositorio : IDiaRepositorio
    {
        private ApplicationDbContext _diaContexto;

        public DiaRepositorio(ApplicationDbContext contexto)
            => _diaContexto = contexto;

        public async Task<IEnumerable<DiaDominio>> ListarAsync() 
            => await _diaContexto.Dias.ToListAsync();

        public async Task<DiaDominio> SelecionarAsync(long id)
            => await _diaContexto.Dias.FindAsync(id);
    }
}
