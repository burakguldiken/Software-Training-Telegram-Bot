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
    public class SendPhotoCommand : ITelegramCommand
    {
        private ITelegramBotClient telegramBotClient { get; set; }

        public SendPhotoCommand(ITelegramClient telegramClient)
        {
            telegramBotClient = telegramClient.CreateInstance();
        }

        public async Task ExecuteCommand(Message message,int category = 1)
        {
            await telegramBotClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                parseMode: ParseMode.Html
            );
        }
    }
}
