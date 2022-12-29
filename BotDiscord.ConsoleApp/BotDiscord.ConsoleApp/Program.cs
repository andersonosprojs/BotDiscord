﻿using BotDiscord.ConsoleApp;
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
        _bots = CarregarBots();


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