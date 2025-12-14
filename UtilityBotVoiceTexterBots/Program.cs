using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Input;
using Telegram.Bot;
using TelegramCalcBot.Bot;
using TelegramCalcBot.Commands;
using TelegramCalcBot.Controllers;
using TelegramCalcBot.Services;
using ICommand = TelegramCalcBot.Commands.ICommand;

namespace TelegramCalcBot;

class Program
{
    static async Task Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<ITelegramBotClient>(
                    new TelegramBotClient("ВАШ_ТОКЕН"));

                // Services
                services.AddSingleton<MenuService>();

                // Commands
                services.AddSingleton<ICommand, StartCommand>();
                services.AddSingleton<ICommand, SumCommand>();
                services.AddSingleton<CommandDispatcher>();

                // Controllers
                services.AddSingleton<TextMessageController>();
                services.AddSingleton<CallbackQueryController>();

                // Bot
                services.AddHostedService<BotHostedService>();
            })
            .Build();

        await host.RunAsync();
    }
}
