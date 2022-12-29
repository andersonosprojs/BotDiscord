using System.ComponentModel.DataAnnotations;

namespace BotDiscord.Aplicacao.Modelos
{
    public class BotModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Mensagem é obrigatória")]
        [MaxLength(300)]
        public List<string> Message { get; set; }

        [Required(ErrorMessage = "Hora é obrigatória")]
        public int Hours { get; set; }

        public bool Execute { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "Dias são obrigatórios")]
        public List<int> Days { get; set; }

    }
}
