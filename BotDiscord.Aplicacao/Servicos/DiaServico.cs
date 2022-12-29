using AutoMapper;
using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using BotDiscord.Dominio.Entidades;
using BotDiscord.Dominio.Interfaces;

namespace BotDiscord.Aplicacao.Servicos
{
    public class DiaServico : IDiaServico
    {
        private readonly IDiaRepositorio _diaRepositorio;
        private readonly IMapper _mapper;

        public DiaServico(
            IDiaRepositorio diaRepositorio,
            IMapper mapper)
        {
            _diaRepositorio = diaRepositorio;
            _mapper = mapper;
        }        

        public async Task<IEnumerable<DiaModel>> ListarAsync()
        {
            var diaDominio = await _diaRepositorio.ListarAsync();
            return _mapper.Map<IEnumerable<DiaModel>>(diaDominio);
        }

        public async Task<DiaModel> SelecionarAsync(long id)
        {
            var diaDominio = await _diaRepositorio.SelecionarAsync(id);
            return _mapper.Map<DiaModel>(diaDominio);
        }
    }
}
