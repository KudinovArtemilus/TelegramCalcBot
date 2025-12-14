using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Models;
using TelegramCalcBot.Services;
using TelegramCalcBot.State;

namespace TelegramCalcBot.Controllers;

public class CallbackQueryController
{
    private readonly ITelegramBotClient _bot;
    private readonly MenuService _menu;

    public CallbackQueryController(
        ITelegramBotClient bot,
        MenuService menu)
    {
        _bot = bot;
        _menu = menu;
    }

    public async Task Handle(CallbackQuery query, CancellationToken ct)
    {
        long chatId = query.Message!.Chat.Id;

        switch (query.Data)
        {
            case "count":
                UserState.Set(chatId, UserMode.CountSymbols);
                await _bot.SendMessage(
                    chatId,
                    "Введите текст",
                    cancellationToken: ct);
                break;

            case "sum":
                UserState.Set(chatId, UserMode.SumNumbers);
                await _bot.SendMessage(
                    chatId,
                    "Введите числа или /sum",
                    cancellationToken: ct);
                break;

            case "back":
                await _menu.ShowMainMenu(chatId, ct);
                break;
        }

        // ОБЯЗАТЕЛЬНО
        await _bot.AnswerCallbackQuery(query.Id, cancellationToken: ct);
    }
}
