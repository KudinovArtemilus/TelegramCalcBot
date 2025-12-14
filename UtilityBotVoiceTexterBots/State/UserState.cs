using TelegramCalcBot.Models;

namespace TelegramCalcBot.State;

public static class UserState
{
    private static readonly Dictionary<long, UserMode> _states = new();

    public static void Set(long chatId, UserMode mode)
        => _states[chatId] = mode;

    public static UserMode Get(long chatId)
        => _states.TryGetValue(chatId, out var mode)
            ? mode
            : UserMode.None;
}
