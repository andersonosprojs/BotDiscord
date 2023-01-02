using BotDiscord.ConsoleApp;
using BotDiscord.ConsoleApp.Modelos;
using Newtonsoft.Json.Linq;
using PuppeteerSharp;
using System.Configuration;
using System.Text.Json;

internal class Program
{
    static string _message = "";
    static string _initialDate = $"{DateTime.Now.Year.ToString("D4")}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}";
    static List<BotModel>? _bots;
    static ConfigModel? _configuracao;
    static string? _urlApi;

    private static async Task Main(string[] args)
    {
        var login = ConfigurationManager.AppSettings["login"];
        var password = ConfigurationManager.AppSettings["password"];
        var cripto = new CriptografiaServico();

        Console.Clear();
        _urlApi = ConfigurationManager.AppSettings["urlapi"];

        Console.WriteLine("Carregando Configuração");
        CarregarConfiguracao();

        Console.WriteLine("");
        Console.WriteLine("Carregando Bots");
        _bots = CarregarBotsLocal();


        Console.WriteLine("");
        Console.WriteLine($"{_initialDate}: Iniciando processo de execução dos bots");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Aguardando bot para execução");
            awaitBot();

            if (_message != "")
            {
                var launchOptions = new LaunchOptions()
                {
                    Headless = false, // Exibir ou não no navegador
                    DefaultViewport = new ViewPortOptions() // Altera dimensões da página
                    {
                        Width = _configuracao.Width,
                        Height = _configuracao.Height - 150
                    },
                    UserDataDir = _configuracao.UserDataDir, // Caminho do usuário. Pra evitar de ficar fazendo login várias vezes
                    ExecutablePath = _configuracao.ExecutablePath
                };

                using (var browser = await Puppeteer.LaunchAsync(launchOptions))
                using (var page = await browser.NewPageAsync())
                {
                    await page.SetUserAgentAsync(
                        $"--window - size ={_configuracao.Width},{_configuracao.Height}" // Altera dimensões do navegador
                    );

                    await page.GoToAsync("https://discord.com/login");

                    Console.WriteLine("");
                    Console.WriteLine("Fazendo os preparativos para execução do bot. Aguarde...");

                    try
                    {
                        // login no discord se for a primeira vez
                        await page.WaitForSelectorAsync("#uid_5", new WaitForSelectorOptions() { Timeout = _configuracao.TimeoutClose });
                        await page.TypeAsync("#uid_5", login);
                        await page.TypeAsync("#uid_8", cripto.Descriptografar(password));
                        await page.Keyboard.PressAsync("Enter");
                        await page.WaitForTimeoutAsync(_configuracao.TimeoutClose);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        try
                        {
                            // Acessa canal configurado
                            await page.GoToAsync(_configuracao.Channel);
                            await page.WaitForTimeoutAsync(_configuracao.TimeoutClose);

                            // envio da mensagem
                            await page.WaitForSelectorAsync(".emptyText-1o0WH_");
                            await page.TypeAsync(".emptyText-1o0WH_", _message);
                            await page.Keyboard.PressAsync("Enter");

                            var hour = $"{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}";
                            Console.WriteLine("");
                            Console.WriteLine($"{ hour} Mensagem: { _message} enviada");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Não foi possível enviar a mensagem. Erro: {ex.Message}");
                            Console.WriteLine("");
                        }
                        finally
                        {
                            _message = "";
                            await page.WaitForTimeoutAsync(_configuracao.TimeoutClose);
                            await browser.CloseAsync();
                        }
                    }
                }
            }
        }
    }

    static List<BotModel> CarregarBots()
    {
        using (HttpClient http = new HttpClient())
        {
            var result = http.GetAsync($"{_urlApi}api/bot/listar").Result;
            var json = result.Content.ReadAsStringAsync().Result;
            var bots = JsonSerializer.Deserialize<List<BotModel>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return bots;
        }
    }

    static List<BotModel> CarregarBotsLocal()
    {
        var bots = new List<BotModel>();
        bots.Add(new BotModel(1, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Bom dia, Pessoal! ☀️ Bora bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 728, true, true));
        bots.Add(new BotModel(2, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Daily vai começar em breve... https://meet.jit.si/ClassJokers" }, new() { 1, 2, 3, 4, 5 }, 758, true, true));
        bots.Add(new BotModel(3, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Quem estiver em **chamados** dá uma olhada se o **Monitor Reinf** no servidor está 🆗" }, new() { 1, 2, 3, 4, 5 }, 800, true, true));
        bots.Add(new BotModel(4, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1148, true, true));
        bots.Add(new BotModel(5, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1158, true, true));
        bots.Add(new BotModel(6, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1228, true, true));
        bots.Add(new BotModel(7, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Anderson Silva#8777 ** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1248, true, true));
        bots.Add(new BotModel(8, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1258, true, true));
        bots.Add(new BotModel(9, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Saída para o almoço" }, new() { 1, 2, 3, 4, 5 }, 1258, true, true));
        bots.Add(new BotModel(10, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Ana Paula Barony#3212** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1328, true, true));
        bots.Add(new BotModel(11, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  ( **@Vladimir Lara#2790** e ** @tarcisia.luciano#8800** ) bater ponto ⏰ - Volta do almoço" }, new() { 1, 2, 3, 4, 5 }, 1358, true, true));
        bots.Add(new BotModel(12, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" }, new() { 1, 2, 3, 4, 5 }, 1415, true, true));
        bots.Add(new BotModel(13, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  **@Catarina Saville#4042**, **@Rafael Miranda#8211** e **@Paulo Gustavo Lacerda#6849**, por hoje é só! Não esqueçam de bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 1428, true, true));
        bots.Add(new BotModel(14, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Final do dia chegando, hora boa pra **atualizar o pace** e/ou **movimentar tarefas** 👍" }, new() { 1, 2, 3, 4, 5 }, 1648, true, true));
        bots.Add(new BotModel(15, new() { "🤖 **⚠️ ATENÇÃO ⚠️**  Até amanhã, Pessoal! Não esqueçam de bater ponto ⏰",
                                          "🤖 **⚠️ ATENÇÃO ⚠️**  Bom final de semana, Pessoal! Não esqueçam de bater ponto ⏰" }, new() { 1, 2, 3, 4, 5 }, 1658, true, true));
        return bots;
    }

    static void CarregarConfiguracao()
    {
        _configuracao = new ConfigModel();
        _configuracao.UserDataDir = ConfigurationManager.AppSettings["userdatadir"];
        _configuracao.ExecutablePath = ConfigurationManager.AppSettings["executablepath"];
        _configuracao.Headless = bool.Parse(ConfigurationManager.AppSettings["headless"]);
        _configuracao.Height = int.Parse(ConfigurationManager.AppSettings["height"]);
        _configuracao.Width = int.Parse(ConfigurationManager.AppSettings["width"]);
        _configuracao.Channel = ConfigurationManager.AppSettings["channel"];
        _configuracao.TimeoutClose = int.Parse(ConfigurationManager.AppSettings["TimeoutClose"]);
    }

    static void awaitBot()
    {
        var hours = 0;
        var weekDay = 0;

        while (string.IsNullOrEmpty(_message))
        {

            // Para o próximo dia os bots são reiniciados
            var dateNow = $"{DateTime.Now.Year.ToString("D4")}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}";
            if (long.Parse(dateNow) > long.Parse(_initialDate))
            {
                Console.WriteLine("");
                Console.WriteLine("Novo dia detectado. Reiniciando bots para execução");
                Console.WriteLine("");

                _bots.ForEach(bot => { bot.Execute = true; });

                _initialDate = dateNow;
                _message = "";

                Console.WriteLine($"{_initialDate}: Iniciando processo de execução dos bots");
                Console.WriteLine("");
                break;
            }

            hours = int.Parse($"{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}");
            weekDay = ((int)DateTime.Now.DayOfWeek);

            _bots.ForEach(bot =>
            {
                if (bot.Execute)
                {
                    bot.Days.ForEach(day =>
                    {
                        if (bot.Active && weekDay == day && hours == bot.Hours)
                        {
                            _message = day == 5 && bot.Message.Count > 1 ? bot.Message[1] : bot.Message[0];
                            bot.Execute = false;
                            return;
                        }
                    });
                }
                if (_message != "") return;
            });
        }
    }
}