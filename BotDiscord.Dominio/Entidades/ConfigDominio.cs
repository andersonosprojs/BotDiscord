using BotDiscord.Dominio.Validacao;

namespace BotDiscord.Dominio.Entidades
{
    public class ConfigDominio: EntidadeBase
    {
        public ConfigDominio(string userDataDir, string executablePath, bool headless, int height,
            int width, string channel, int timeoutClose)
            => ValidaDominio(userDataDir, executablePath, headless, height,
            width, channel, timeoutClose);

        public ConfigDominio(long id, string userDataDir, string executablePath, bool headless, int height,
            int width, string channel, int timeoutClose)
        {
            ValidacaoDominio.When(id < 0, "Indentificador Inválido");
            Id = id;
            ValidaDominio(userDataDir, executablePath, headless, height,
            width, channel, timeoutClose);
        }

        public string UserDataDir { get; private set; }
        public string ExecutablePath { get; private set; }
        public bool Headless { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string Channel { get; set; }
        public int TimeoutClose { get; set; }


        private void ValidaDominio(string userDataDir, string executablePath, bool headless, int height,
            int width, string channel, int timeoutClose)
        {
            ValidacaoDominio.When(string.IsNullOrEmpty(userDataDir),
                "Caminho do diretório de Usuário do Chrome é obrigatório");

            ValidacaoDominio.When(string.IsNullOrEmpty(executablePath),
                "Caminho do executável do Chrome é obrigatório");

            ValidacaoDominio.When(string.IsNullOrEmpty(channel),
                "Canal onde será emitido as mensagem é obrigatório");

            UserDataDir = userDataDir;
            ExecutablePath = executablePath;
            Headless = headless;
            Height = height;
            Width = width;
            Channel = channel;
            TimeoutClose = timeoutClose;
        }
    }
}
