using SoftwareTraining.Client;
using SoftwareTraining.TelegramCommand.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SoftwareTraining.TelegramCommand.Service
{
    public class SendMessageCommand : ITelegramCommand
    {
        private ITelegramBotClient telegramBotClient { get; set; }

        public SendMessageCommand(ITelegramClient telegramClient)
        {
            telegramBotClient = telegramClient.CreateInstance();
        }

        public async Task ExecuteCommand(Message message,int category = 1)
        {
            await telegramBotClient.SendTextMessageAsync(message.Chat.Id, "<html><b>bold</b>, <strong>bold</strong></html>", (ParseMode.Html));
        }
    }
}
