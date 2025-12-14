using Telegram.Bot.Types;

namespace TelegramCalcBot.Commands;

public class CommandDispatcher
{
    private readonly IEnumerable<ICommand> _commands;

    public CommandDispatcher(IEnumerable<ICommand> commands)
    {
        _commands = commands;
    }

    public async Task<bool> TryHandle(Message message, CancellationToken ct)
    {
        if (message.Text == null || !message.Text.StartsWith("/"))
            return false;

        var parts = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var commandName = parts[0];
        var args = parts.Skip(1).ToArray();

        var command = _commands.FirstOrDefault(c => c.Name == commandName);
        if (command == null)
            return false;

        await command.Execute(message, args, ct);
        return true;
    }
}
