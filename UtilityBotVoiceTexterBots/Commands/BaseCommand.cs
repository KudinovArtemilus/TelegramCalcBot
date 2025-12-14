using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramCalcBot.Commands;

public abstract class BaseCommand : ICommand
{
    protected readonly ITelegramBotClient Bot;

    protected BaseCommand(ITelegramBotClient bot)
    {
        Bot = bot;
    }

    public abstract string Name { get; }

    public abstract Task Execute(
        Message message,
        string[] args,
        CancellationToken ct);
}
