using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Commands;
using TelegramCalcBot.Keyboards;
using TelegramCalcBot.Models;
using TelegramCalcBot.State;

namespace TelegramCalcBot.Controllers;

public class TextMessageController
{
    private readonly CommandDispatcher _dispatcher;
    private readonly ITelegramBotClient _bot;

    public TextMessageController(
        CommandDispatcher dispatcher,
        ITelegramBotClient bot)
    {
        _dispatcher = dispatcher;
        _bot = bot;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        if (await _dispatcher.TryHandle(message, ct))
            return;

        long chatId = message.Chat.Id;

        if (UserState.Get(chatId) == UserMode.CountSymbols)
        {
            await _bot.SendMessage(
                chatId,
                $"В вашем сообщении {message.Text.Length} символов",
                replyMarkup: InlineMenus.BackMenu,
                cancellationToken: ct);
        }
    }
}
