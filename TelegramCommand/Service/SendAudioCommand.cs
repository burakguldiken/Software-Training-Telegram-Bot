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
    public class SendAudioCommand : ITelegramCommand
    {
        private ITelegramBotClient telegramBotClient { get; set; }

        public SendAudioCommand(ITelegramClient telegramClient)
        {
            telegramBotClient = telegramClient.CreateInstance();
        }

        public async Task ExecuteCommand(Message message,int category = 1)
        {
            await telegramBotClient.SendAudioAsync(
                message.Chat.Id,
                "https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"
            );
        }
    }
}
