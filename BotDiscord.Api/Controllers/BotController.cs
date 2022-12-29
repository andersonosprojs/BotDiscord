using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace BotDiscord.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IBotServico _botServico;

        public BotController(IBotServico botServico)
        {
            _botServico = botServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BotModel>>> ListarAsync()
        {
            var bots = await _botServico.ListarAsync();
            if (bots == null)
                return NotFound("Não existe bots");

            return Ok(bots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BotModel>> SelecionarAsync(long id)
        {
            var bot = await _botServico.SelecionarAsync(id);
            if (bot == null)
                return NotFound("Bot não encontrada");

            return Ok(bot);
        }

        [HttpPost]
        public async Task<ActionResult<BotModel>> SalvarAsync([FromBody] BotModel bot)
        {
            if (bot == null)
                return BadRequest("Dados inválidos");

            await _botServico.SalvarAsync(bot);

            return Ok(bot);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BotModel>> ExcluirAsync(long id)
        {
            var bot = await _botServico.SelecionarAsync(id);
            if (bot == null)
                return NotFound("Bot não existe");

            await _botServico.ExcluirAsync(id);

            return Ok(bot);
        }
    }
}
