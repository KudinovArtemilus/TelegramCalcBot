using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramCalcBot.Keyboards;

public static class InlineMenus
{
    public static InlineKeyboardMarkup MainMenu =>
        new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("🔤 Подсчёт символов", "count") },
            new[] { InlineKeyboardButton.WithCallbackData("➕ Сумма чисел", "sum") }
        });

    public static InlineKeyboardMarkup BackMenu =>
        new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("🔙 Назад", "back") }
        });
}
