using System.ComponentModel.DataAnnotations;

namespace BotDiscord.Aplicacao.Modelos
{
    public class ConfigModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Caminho do diretório de Usuário do Chrome é obrigatório")]
        public string UserDataDir { get; set; }

        [Required(ErrorMessage = "Caminho do executável do Chrome é obrigatório")]
        public string ExecutablePath { get; set; }
        
        public bool Headless { get; set; }
        
        public int Height { get; set; }
        
        public int Width { get; set; }

        [Required(ErrorMessage = "Canal onde será emitido as mensagem é obrigatório")]
        [MaxLength(2000)]
        public string Channel { get; set; }        

        public int TimeoutClose { get; set; }
    }
}
