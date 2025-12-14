using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Commands;
using TelegramCalcBot.Bot;

namespace TelegramCalcBot.Commands;

public class SumCommand : BaseCommand
{
    public SumCommand(ITelegramBotClient bot) : base(bot) { }

    public override string Name => "/sum";

    public override async Task Execute(
        Message message,
        string[] args,
        CancellationToken ct)
    {
        long chatId = message.Chat.Id;

        if (args.Length == 0)
        {
            await Bot.SendMessage(
                chatId,
                "Пример: /sum 1 2 3",
                cancellationToken: ct);
            return;
        }

        try
        {
            int sum = args.Select(int.Parse).Sum();
            await Bot.SendMessage(
                chatId,
                $"Сумма чисел: {sum}",
                cancellationToken: ct);
        }
        catch
        {
            await Bot.SendMessage(
                chatId,
                "Ошибка: вводите только числа",
                cancellationToken: ct);
        }
    }
}
