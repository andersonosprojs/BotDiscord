using System.ComponentModel.DataAnnotations;

namespace BotDiscord.Aplicacao.Modelos
{
    public class DiaModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Descrição do dia é obrigatória")]
        [MaxLength(50)]
        public string Descricao { get; set; }

    }
}
