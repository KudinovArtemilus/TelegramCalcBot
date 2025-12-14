using Telegram.Bot;
using TelegramCalcBot.Keyboards;
using TelegramCalcBot.Models;
using TelegramCalcBot.State;

namespace TelegramCalcBot.Services;

public class MenuService
{
    private readonly ITelegramBotClient _bot;

    public MenuService(ITelegramBotClient bot)
    {
        _bot = bot;
    }

    public async Task ShowMainMenu(long chatId, CancellationToken ct)
    {
        UserState.Set(chatId, UserMode.None);

        await _bot.SendMessage(
            chatId,
            "Выберите действие:",
            replyMarkup: InlineMenus.MainMenu,
            cancellationToken: ct);
    }
}
