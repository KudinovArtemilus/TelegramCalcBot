using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Services;

namespace TelegramCalcBot.Commands;

public class StartCommand : BaseCommand
{
    private readonly MenuService _menu;

    public StartCommand(ITelegramBotClient bot, MenuService menu)
        : base(bot)
    {
        _menu = menu;
    }

    public override string Name => "/start";

    public override async Task Execute(
        Message message,
        string[] args,
        CancellationToken ct)
    {
        await _menu.ShowMainMenu(message.Chat.Id, ct);
    }
}
