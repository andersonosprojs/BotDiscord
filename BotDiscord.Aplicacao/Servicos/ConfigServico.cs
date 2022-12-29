using AutoMapper;
using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;

namespace BotDiscord.Aplicacao.Servicos
{
    public class ConfigServico : IConfigServico
    {
        private readonly IConfigRepositorio _configRepositorio;
        private readonly IMapper _mapper;

        public ConfigServico(
            IConfigRepositorio configRepositorio,
            IMapper mapper)
        {
            _configRepositorio = configRepositorio;
            _mapper = mapper;
        }

        public async Task<ConfigModel> SelecionarAsync()
        {
            var configDominio = await _configRepositorio.SelecionarAsync();
            return _mapper.Map<ConfigModel>(configDominio);
        }

        public async Task AtualizarAsync(ConfigModel configModel)
        {
            var configDominio = _mapper.Map<ConfigDominio>(configModel);
            await _configRepositorio.AtualizarAsync(configDominio);
        }
    }
}
