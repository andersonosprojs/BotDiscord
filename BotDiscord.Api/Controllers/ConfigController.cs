using BotDiscord.Aplicacao.Interfaces;
using BotDiscord.Aplicacao.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace BotDiscord.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigServico _configServico;

        public ConfigController(IConfigServico configServico)
        {
            _configServico = configServico;
        }

        [HttpGet]
        public async Task<ActionResult<ConfigModel>> SelecionarAsync()
        {
            var config = await _configServico.SelecionarAsync();
            if (config == null)
                return NotFound("Config não encontrada");

            return Ok(config);
        }

        [HttpPost]
        public async Task<ActionResult<ConfigModel>> AtualizarAsync([FromBody] ConfigModel config)
        {
            if (config == null)
                return BadRequest("Dados inválidos");

            await _configServico.AtualizarAsync(config);

            return Ok(config);
        }
    }
}
