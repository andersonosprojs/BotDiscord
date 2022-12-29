using AutoMapper;
using BotDiscord.Aplicacao.Modelos;
using BotDiscord.Dominio.Entidades;

namespace BotDiscord.Aplicacao.Mappings
{
    public class DominioModelProfile: Profile
    {
        public DominioModelProfile()
        {
            CreateMap<BotDominio, BotModel>().ReverseMap();
            CreateMap<ConfigDominio, ConfigModel>().ReverseMap();
            CreateMap<DiaDominio, DiaModel>().ReverseMap();
        }
    }
}
