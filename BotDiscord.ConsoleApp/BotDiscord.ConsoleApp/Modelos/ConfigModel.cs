using System.ComponentModel.DataAnnotations;

namespace BotDiscord.ConsoleApp.Modelos
{
    public class ConfigModel
    {
        public long Id { get; set; }

        public string UserDataDir { get; set; }

        public string ExecutablePath { get; set; }
        
        public bool Headless { get; set; }
        
        public int Height { get; set; }
        
        public int Width { get; set; }

        public string Channel { get; set; }

        public int TimeoutClose { get; set; }
    }
}
