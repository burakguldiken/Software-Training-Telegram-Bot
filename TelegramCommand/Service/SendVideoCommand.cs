using SoftwareTraining.Client;
using SoftwareTraining.TelegramCommand.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SoftwareTraining.TelegramCommand.Service
{
    public class SendVideoCommand : ITelegramCommand
    {
        private ITelegramBotClient telegramBotClient { get; set; }

        public SendVideoCommand(ITelegramClient telegramClient)
        {
            telegramBotClient = telegramClient.CreateInstance();
        }

        public async Task ExecuteCommand(Message message,int category = 1)
        {
            await telegramBotClient.SendVideoAsync(
                  chatId: message.Chat.Id,
                  video: "http://i.imgur.com/OKRRfmN.mp4",
                  supportsStreaming: true
            );
        }
    }
}
