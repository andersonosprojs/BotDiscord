using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace BotDiscord.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiaController : ControllerBase
    {
        private readonly IDiaServico _diaServico;

        public DiaController(IDiaServico diaServico)
        {
            _diaServico = diaServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaModel>>> ListarAsync()
        {
            var dias = await _diaServico.ListarAsync();
            if (dias == null)
                return NotFound("Não existe dias");

            return Ok(dias);
        }

        [HttpGet]
        public async Task<ActionResult<DiaModel>> SelecionarAsync(long id)
        {
            var dia = await _diaServico.SelecionarAsync(id);
            if (dia == null)
                return NotFound("Dia não encontrada");

            return Ok(dia);
        }


    }
}
