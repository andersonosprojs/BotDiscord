using System.ComponentModel.DataAnnotations;

namespace BotDiscord.ConsoleApp.Modelos
{
    public class BotModel
    {
        public BotModel(long id, List<string> message, List<int> days, int hours, bool execute, bool active)
        {
            Id = id;
            Message = message;
            Hours = hours;
            Execute = execute;
            Active = active;
            Days = days;
        }

        public long Id { get; set; }

        public List<string> Message { get; set; }

        public int Hours { get; set; }

        public bool Execute { get; set; }

        public bool Active { get; set; }

        public List<int> Days { get; set; }

    }
}
