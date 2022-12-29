using AutoMapper;
using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;

namespace BotDiscord.Aplicacao.Servicos
{
    public class BotServico : IBotServico
    {
        private readonly IBotRepositorio _botRepositorio;
        private readonly IMapper _mapper;

        public BotServico(
            IBotRepositorio botRepositorio,
            IMapper mapper)
        {
            _botRepositorio = botRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BotModel>> ListarAsync()
        {
            var botDominio = await _botRepositorio.ListarAsync();
            return _mapper.Map<IEnumerable<BotModel>>(botDominio);
        }

        public async Task<BotModel> SelecionarAsync(long id)
        {
            var botDominio = await _botRepositorio.SelecionarAsync(id);
            return _mapper.Map<BotModel>(botDominio);
        }

        public async Task SalvarAsync(BotModel botModel)
        {
            var botDominio = _mapper.Map<BotDominio>(botModel);
            await _botRepositorio.SalvarAsync(botDominio);
            botModel.Id = botDominio.Id;
        }

        public async Task ExcluirAsync(long id)
        {
            var botDominio = _botRepositorio.SelecionarAsync(id).Result;
            await _botRepositorio.ExcluirAsync(botDominio);
        }
    }
}
