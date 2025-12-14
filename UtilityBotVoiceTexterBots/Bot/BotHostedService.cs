using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Controllers;

namespace TelegramCalcBot.Bot;

public class BotHostedService : BackgroundService
{
    private readonly ITelegramBotClient _bot;
    private readonly TextMessageController _text;
    private readonly CallbackQueryController _callback;

    public BotHostedService(
        ITelegramBotClient bot,
        TextMessageController text,
        CallbackQueryController callback)
    {
        _bot = bot;
        _text = text;
        _callback = callback;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _bot.StartReceiving(
            async (bot, update, ct) =>
            {
                if (update.Message != null)
                    await _text.Handle(update.Message, ct);

                if (update.CallbackQuery != null)
                    await _callback.Handle(update.CallbackQuery, ct);
            },
            (_, _, _) => Task.CompletedTask,
            cancellationToken: stoppingToken);

        await Task.Delay(-1, stoppingToken);
    }
}
