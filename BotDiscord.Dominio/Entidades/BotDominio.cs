using BotDiscord.Dominio.Validacao;

namespace BotDiscord.Dominio.Entidades
{
    public class BotDominio: EntidadeBase
    {
        public BotDominio(List<string> message, List<int> days, int hours, bool execute, bool active)
        {
            ValidaDominio(message, days, hours, execute, active);
        }

        public BotDominio(long id, List<string> message, List<int> days, int hours, bool execute, bool active)
        {
            ValidacaoDominio.When(id < 0, "Indentificador Inválido");
            Id = id;
            ValidaDominio(message, days, hours, execute, active);
        }

        public List<string> Message { get; private set; }
        public int Hours { get; private set; }
        public bool Execute { get; private set; }
        public bool Active { get; private set; }
        public List<int> Days { get; set; }

        private void ValidaDominio(List<string> message, List<int> days, int hours, bool execute, bool active)
        {
            ValidacaoDominio.When(message.Count == 0,
                "Mensagem é obrigatória");

            ValidacaoDominio.When(days.Count == 0,
                "Dias são obrigatórios");

            ValidacaoDominio.When(hours == 0,
                "Hora é obrigatória");

            Message = message;
            Days = days;
            Hours = hours;
            Execute = execute;
            Active = active;
        }
    }
}
