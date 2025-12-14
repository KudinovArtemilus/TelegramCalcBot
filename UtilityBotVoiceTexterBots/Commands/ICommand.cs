using Telegram.Bot.Types;

namespace TelegramCalcBot.Commands;

public interface ICommand
{
    string Name { get; }

    Task Execute(
        Message message,
        string[] args,
        CancellationToken ct);
}
